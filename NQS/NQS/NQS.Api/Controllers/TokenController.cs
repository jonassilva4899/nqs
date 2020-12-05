
using Leega.Domain;
using Leega.Domain.Service;
using Leega.Domain.Utils;
using Leega.Entity;
using Leega.Entity.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Leega.Domain.Domain;
using Microsoft.EntityFrameworkCore.Internal;
using Leega.Entity.Enums;
using Microsoft.AspNetCore.Http;
using Leega.Entity.Repositories.Interfaces;
using Google.Apis.Auth;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace JWT.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private readonly LoginServico<UsuarioViewModel, Usuario> _loginServico;
        private readonly OrganizacaoService _organizacaoService;
        private readonly IHttpContextAccessor _contextAccessor;
        IPessoaRepository _pessoaRepository;
        IOrganizacaoRepository _organizacaoRepository;
        IUsuarioRepository _usuarioRepository;
        IOrganizacaoUsuarioRepository _organizacaoUsuarioRepository;
        private OrganizacaoUsuarioRoleEnum _roleEnum { get; set; }

        public TokenController(IConfiguration config,
                               IHttpContextAccessor contextAccessor,
                               LoginServico<UsuarioViewModel, Usuario> loginServico,
                               OrganizacaoService organizacaoService,
                               IPessoaRepository pessoaRepository,
                               IOrganizacaoRepository organizacaoRepository,
                               IUsuarioRepository usuarioRepository,
                               IOrganizacaoUsuarioRepository organizacaoUsuarioRepository)
        {
            if (_pessoaRepository == null)
                _pessoaRepository = pessoaRepository;

            if (_organizacaoRepository == null)
                _organizacaoRepository = organizacaoRepository;

            if (_usuarioRepository == null)
                _usuarioRepository = usuarioRepository;

            if (_organizacaoUsuarioRepository == null)
                _organizacaoUsuarioRepository = organizacaoUsuarioRepository;

            _config = config;
            _loginServico = loginServico;
            _organizacaoService = organizacaoService;
            _contextAccessor = contextAccessor;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                UsuarioLogadoViewModel usuario = await Autentica(login);

                if (usuario != null)
                {
                    usuario.Token = await CriaToken(usuario);
                    return Ok(usuario);
                }

                return Unauthorized();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("LoginComGoogle")]
        public async Task<IActionResult> LoginComGoogle([FromBody] UsuarioSocialViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            IActionResult response = Unauthorized();

            var usuarioLogado = await AutenticaComGoogle(usuario);
            if (usuarioLogado != null)
            {
                usuarioLogado.Token = await CriaToken(usuarioLogado, usuario.IdToken);
                if (usuarioLogado.Token == null)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }
                return Ok(usuarioLogado);
            }

            return Unauthorized();
        }

        //[HttpPost("TrocarOrganizacao")]
        //public async Task<IActionResult> TrocaOrganizacao([FromBody]TrocaOrganizacaoViewModel trocaOrganizacaoViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        _roleEnum = (OrganizacaoUsuarioRoleEnum)Enum.Parse(typeof(OrganizacaoUsuarioRoleEnum), _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "RoleEnum")?.Value);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }


        //    List<Guid> idsTimes;
        //    DateTime dataCriacao;
        //    Guid idOrganizacao;
        //    OrganizacaoUsuarioRoleEnum roleEnum;

        //    if (_roleEnum == OrganizacaoUsuarioRoleEnum.GoobeeAdmin)
        //    {
        //        var usuario = await _usuarioRepository.PegarUsuario(x => x.Id == trocaOrganizacaoViewModel.IdUsuario);
        //        var pessoa = await _pessoaRepository.BuscarPorEmail(usuario.Login);
        //        idsTimes = new List<Guid>();
        //        dataCriacao = DateTime.Now;
        //        idOrganizacao = trocaOrganizacaoViewModel.IdOrganizacao;
        //        roleEnum = OrganizacaoUsuarioRoleEnum.GoobeeAdmin;

        //        pessoa.IdUltimaOrgAcessada = trocaOrganizacaoViewModel.IdOrganizacao;
        //        _pessoaRepository.Update(pessoa);

        //        if (pessoa != null)
        //        {
        //            var usuarioLogado = new UsuarioLogadoViewModel()
        //            {
        //                DataCriacao = DateTime.Now,
        //                Email = pessoa.Email,
        //                Nome = pessoa.Nome,
        //                Foto = pessoa.Foto,
        //                Id = usuario.Id,
        //                IdPessoa = pessoa.Id,
        //                IdOrganizacao = idOrganizacao,
        //                RoleEnum = roleEnum,
        //                IdsTimes = idsTimes
        //            };

        //            usuarioLogado.Token = await CriaToken(usuarioLogado);

        //            _pessoaRepository.Save();

        //            return Ok(usuarioLogado);
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            OrganizacaoUsuario pessoa;
        //            List<OrganizacaoUsuario> organizacoesUsuario;
        //            organizacoesUsuario = await _organizacaoService.ListarOrganizacoesUsuario(trocaOrganizacaoViewModel.IdUsuario);

        //            foreach (var org in organizacoesUsuario)
        //            {
        //                if (org.IdOrganizacao == trocaOrganizacaoViewModel.IdOrganizacao)
        //                    org.UltimaAcessada = true;
        //                else
        //                    org.UltimaAcessada = false;
        //            }

        //            _organizacaoUsuarioRepository.UpdateRange(organizacoesUsuario);

        //            pessoa = organizacoesUsuario.FirstOrDefault(x => x.IdOrganizacao == trocaOrganizacaoViewModel.IdOrganizacao);


        //            if (pessoa != null)
        //            {
        //                idsTimes = new List<Guid>();
        //                foreach (var timePessoa in pessoa.Pessoa.TimePessoas)
        //                {
        //                    if (timePessoa.IdOrganizacao == pessoa.IdOrganizacao)
        //                        idsTimes.Add(timePessoa.IdTime);
        //                }
        //                dataCriacao = pessoa.DataCriacao;
        //                idOrganizacao = pessoa.IdOrganizacao;
        //                roleEnum = pessoa.OrganizacaoUsuarioRole.Role;

        //                var usuarioLogado = new UsuarioLogadoViewModel()
        //                {
        //                    DataCriacao = dataCriacao,
        //                    Email = pessoa.Pessoa.Email,
        //                    Nome = pessoa.Pessoa.Nome,
        //                    Foto = pessoa.Pessoa.Foto,
        //                    Id = pessoa.IdUsuario.Value,
        //                    IdPessoa = pessoa.IdPessoa,
        //                    IdOrganizacao = idOrganizacao,
        //                    RoleEnum = roleEnum,
        //                    IdsTimes = idsTimes
        //                };

        //                usuarioLogado.Token = await CriaToken(usuarioLogado);

        //                _organizacaoUsuarioRepository.Save();

        //                return Ok(usuarioLogado);
        //            }
        //        }
        //        catch
        //        {
        //            return BadRequest();
        //        }
        //    }

        //    return StatusCode(401);
        //}

        private async Task<string> CriaToken(UsuarioLogadoViewModel user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Nome));
            claims.Add(new Claim("IdOrganizacao", user.IdOrganizacao.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Birthdate, user.DataCriacao.ToString("yyyy-MM-dd")));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            //Anexando a Role
            switch (user.RoleEnum)
            {
                case OrganizacaoUsuarioRoleEnum.GoobeeAdmin:
                    claims.Add(new Claim(ClaimTypes.Role, RolesNomes.GoobeeAdmin));
                    claims.Add(new Claim("RoleEnum", user.RoleEnum.ToString()));
                    break;
                case OrganizacaoUsuarioRoleEnum.OrganizationAdmin:
                    claims.Add(new Claim(ClaimTypes.Role, RolesNomes.OrganizationAdmin));
                    claims.Add(new Claim("RoleEnum", user.RoleEnum.ToString()));
                    break;
                case OrganizacaoUsuarioRoleEnum.AgileCoach:
                    claims.Add(new Claim(ClaimTypes.Role, RolesNomes.AgileCoach));
                    claims.Add(new Claim("RoleEnum", user.RoleEnum.ToString()));
                    break;
                case OrganizacaoUsuarioRoleEnum.TeamLeader:
                    claims.Add(new Claim(ClaimTypes.Role, RolesNomes.TeamLeader));
                    claims.Add(new Claim("RoleEnum", user.RoleEnum.ToString()));
                    break;
                default:
                    claims.Add(new Claim(ClaimTypes.Role, RolesNomes.TeamMember));
                    claims.Add(new Claim("RoleEnum", user.RoleEnum.ToString()));
                    break;
            }

            //attach roles
            //foreach (string role in user.Roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               _config["Jwt:Issuer"],
               _config["Jwt:Issuer"],
               claims,
              expires: DateTime.Now.AddMinutes(600),  //60 min expiry and a client monitor token quality and should request new token with this one expiries
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<string> CriaToken(UsuarioLogadoViewModel usuario, string idTokenGoogle = "")
        {
            if (!string.IsNullOrWhiteSpace(idTokenGoogle))
            {
                var eValido = await ValidaTokenGoogle(idTokenGoogle, usuario);
                if (!eValido)
                {
                    return null;
                }
            }

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.Nome));
            claims.Add(new Claim("IdOrganizacao", usuario.IdOrganizacao.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, usuario.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Birthdate, usuario.DataCriacao.ToString("yyyy-MM-dd")));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            //Anexando a Role
            switch (usuario.RoleEnum)
            {
                case OrganizacaoUsuarioRoleEnum.GoobeeAdmin:
                    claims.Add(new Claim(ClaimTypes.Role, RolesNomes.GoobeeAdmin));
                    claims.Add(new Claim("RoleEnum", usuario.RoleEnum.ToString()));
                    break;
                case OrganizacaoUsuarioRoleEnum.OrganizationAdmin:
                    claims.Add(new Claim(ClaimTypes.Role, RolesNomes.OrganizationAdmin));
                    claims.Add(new Claim("RoleEnum", usuario.RoleEnum.ToString()));
                    break;
                case OrganizacaoUsuarioRoleEnum.AgileCoach:
                    claims.Add(new Claim(ClaimTypes.Role, RolesNomes.AgileCoach));
                    claims.Add(new Claim("RoleEnum", usuario.RoleEnum.ToString()));
                    break;
                case OrganizacaoUsuarioRoleEnum.TeamLeader:
                    claims.Add(new Claim(ClaimTypes.Role, RolesNomes.TeamLeader));
                    claims.Add(new Claim("RoleEnum", usuario.RoleEnum.ToString()));
                    break;
                default:
                    claims.Add(new Claim(ClaimTypes.Role, RolesNomes.TeamMember));
                    claims.Add(new Claim("RoleEnum", usuario.RoleEnum.ToString()));
                    break;
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               _config["Jwt:Issuer"],
               _config["Jwt:Issuer"],
               claims,
              expires: DateTime.Now.AddMinutes(600),  //60 min expiry and a client monitor token quality and should request new token with this one expiries
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<bool> ValidaTokenGoogle(string idToken, UsuarioLogadoViewModel obj = null)
        {
            try
            {
                ValidationSettings validation = new ValidationSettings()
                {
                    ForceGoogleCertRefresh = true,
                    Audience = null,
                    IssuedAtClockTolerance = TimeSpan.FromMinutes(5),
                    ExpirationTimeClockTolerance = TimeSpan.FromMinutes(5)
                };

                var resposta = await GoogleJsonWebSignature.ValidateAsync(idToken, validation);
                if (resposta == null)
                {
                    return false;
                }
                else
                {
                    if (obj != null)
                    {
                        if (resposta.Email != obj.Email)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (InvalidJwtException error)
            {
                return false;
            }
            catch (Exception error)
            {
                return false;
            }

            return true;
        }


        private async Task<UsuarioLogadoViewModel> Autentica(Login login)
        {
            if (login != null)
            {
                var usuario = await _loginServico.VerificaLoginSenha(login);
                var organizacoes = await _organizacaoService.ListarOrganizacoesUsuarioEmail(usuario.Login);

                OrganizacaoUsuario organizacaoUsuario = null;

                if (organizacoes.Any(x => x.UltimaAcessada))
                    organizacaoUsuario = organizacoes.FirstOrDefault(x => x.UsuarioPlataforma && x.UltimaAcessada);
                else
                    organizacaoUsuario = organizacoes.FirstOrDefault(x => x.UsuarioPlataforma);

                var pessoa = await _pessoaRepository.BuscarPorEmail(usuario.Login);

                if (!usuario.Ativo)
                {
                    return null;
                }

                UsuarioLogadoViewModel usuarioLogado = null;

                if (!pessoa.GoobeeAdmin)
                {
                    if (organizacaoUsuario == null || !organizacaoUsuario.IdUsuario.HasValue)
                    {
                        return null;
                    }

                    if (organizacaoUsuario.Pessoa == null || organizacaoUsuario.Pessoa.Status == false)
                    {
                        return null;
                    }

                    List<Guid> idsTimes = new List<Guid>();
                    foreach (var timePessoa in organizacaoUsuario.Pessoa.TimePessoas)
                    {
                        if (!timePessoa.Status)
                            continue;

                        if (timePessoa.IdOrganizacao == organizacaoUsuario.IdOrganizacao)
                            idsTimes.Add(timePessoa.IdTime);
                    }

                    usuarioLogado = new UsuarioLogadoViewModel()
                    {
                        DataCriacao = organizacaoUsuario.Pessoa.DataCriacao,
                        Email = organizacaoUsuario.Pessoa.Email,
                        Nome = organizacaoUsuario.Pessoa.Nome,
                        Foto = organizacaoUsuario.Pessoa.Foto,
                        Id = organizacaoUsuario.IdUsuario.Value,
                        IdPessoa = organizacaoUsuario.IdPessoa,
                        IdOrganizacao = organizacaoUsuario.IdOrganizacao,
                        RoleEnum = organizacaoUsuario.OrganizacaoUsuarioRole.Role,
                        IdsTimes = idsTimes
                    };
                }
                else
                {
                    Guid? idOrganizacao;

                    if (pessoa.IdUltimaOrgAcessada.HasValue)
                        idOrganizacao = pessoa.IdUltimaOrgAcessada.Value;
                    else
                        idOrganizacao = _organizacaoRepository.GetAll().FirstOrDefault()?.Id;

                    usuarioLogado = new UsuarioLogadoViewModel()
                    {
                        DataCriacao = DateTime.Now,
                        Email = pessoa.Email,
                        Nome = pessoa.Nome,
                        Foto = pessoa.Foto,
                        Id = usuario.Id,
                        IdPessoa = pessoa.Id,
                        IdOrganizacao = idOrganizacao,
                        RoleEnum = OrganizacaoUsuarioRoleEnum.GoobeeAdmin,
                        IdsTimes = new List<Guid>()
                    };
                }

                return usuarioLogado;
            }
            return null;
        }

        private async Task<UsuarioLogadoViewModel> AutenticaComGoogle(UsuarioSocialViewModel login)
        {
            if (login != null)
            {
                var usuario = await _loginServico.VerificaLoginGoogle(login);

                if (usuario == null)
                {
                    return null;
                }

                if (!usuario.Ativo)
                {
                    return null;
                }

                if (!usuario.ContaGoogle)
                {
                    return null;
                }

                try
                {
                    var organizacoes = await _organizacaoService.ListarOrganizacoesUsuarioEmail(usuario.Login);

                    OrganizacaoUsuario organizacaoUsuario = null;

                    if (organizacoes.Any(x => x.UltimaAcessada))
                        organizacaoUsuario = organizacoes.FirstOrDefault(x => x.UsuarioPlataforma && x.UltimaAcessada);
                    else
                        organizacaoUsuario = organizacoes.FirstOrDefault(x => x.UsuarioPlataforma);

                    var pessoa = await _pessoaRepository.BuscarPorEmail(usuario.Login);

                    if (!usuario.Ativo)
                    {
                        return null;
                    }

                    UsuarioLogadoViewModel usuarioLogado = null;

                    if (!pessoa.GoobeeAdmin)
                    {
                        if (organizacaoUsuario == null || !organizacaoUsuario.IdUsuario.HasValue)
                        {
                            return null;
                        }

                        if (organizacaoUsuario.Pessoa == null || organizacaoUsuario.Pessoa.Status == false)
                        {
                            return null;
                        }

                        List<Guid> idsTimes = new List<Guid>();
                        foreach (var timePessoa in organizacaoUsuario.Pessoa.TimePessoas)
                        {
                            if (timePessoa.IdOrganizacao == organizacaoUsuario.IdOrganizacao)
                                idsTimes.Add(timePessoa.IdTime);
                        }

                        usuarioLogado = new UsuarioLogadoViewModel()
                        {
                            DataCriacao = organizacaoUsuario.Pessoa.DataCriacao,
                            Email = organizacaoUsuario.Pessoa.Email,
                            Nome = organizacaoUsuario.Pessoa.Nome,
                            Foto = organizacaoUsuario.Pessoa.Foto,
                            Id = organizacaoUsuario.IdUsuario.Value,
                            IdPessoa = organizacaoUsuario.IdPessoa,
                            IdOrganizacao = organizacaoUsuario.IdOrganizacao,
                            RoleEnum = organizacaoUsuario.OrganizacaoUsuarioRole.Role,
                            IdsTimes = idsTimes
                        };
                    }
                    else
                    {
                        Guid? idOrganizacao;

                        if (pessoa.IdUltimaOrgAcessada.HasValue)
                            idOrganizacao = pessoa.IdUltimaOrgAcessada.Value;
                        else
                            idOrganizacao = _organizacaoRepository.GetAll().FirstOrDefault()?.Id;

                        usuarioLogado = new UsuarioLogadoViewModel()
                        {
                            DataCriacao = DateTime.Now,
                            Email = pessoa.Email,
                            Nome = pessoa.Nome,
                            Foto = pessoa.Foto,
                            Id = usuario.Id,
                            IdPessoa = pessoa.Id,
                            IdOrganizacao = idOrganizacao,
                            RoleEnum = OrganizacaoUsuarioRoleEnum.GoobeeAdmin,
                            IdsTimes = new List<Guid>()
                        };
                    }

                    return usuarioLogado;
                }
                catch (Exception error)
                {
                    return null;
                }
            }
            return null;
        }
    }
}