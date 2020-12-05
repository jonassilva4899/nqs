using Google.Apis.Auth;
using Leega.Application.Interfaces;
using Leega.Application.ViewModels;
using Leega.Data.Enums;
using Leega.DataMySql.Entity;
using Leega.DataMySql.Repositories.Interfaces;
using Leega.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Leega.Application.Services
{
    public class LoginMySqlService : BaseMySqlService, ILoginMySqlService
    {
        private IConfiguration _config;
        private readonly IUsuarioMySqlRepository _usuarioMySqlRepository;
        private readonly IOrganizacaoMySqlRepository _organizacaoMySqlRepository;
        private readonly IPessoaMySqlRepository _pessoaMySqlRepository;

        public LoginMySqlService(IConfiguration config,
            IUsuarioMySqlRepository usuarioMySqlRepository,
            IPessoaMySqlRepository pessoaMySqlRepository,
            IOrganizacaoMySqlRepository organizacaoMySqlRepository)
        {
            _config = config;
            _usuarioMySqlRepository = usuarioMySqlRepository;
            _pessoaMySqlRepository = pessoaMySqlRepository;
            _organizacaoMySqlRepository = organizacaoMySqlRepository;
        }

        public async Task<UsuarioLogadoMySqlViewModel> Autentica(LoginMySql login)
        {
            UsuarioLogadoMySqlViewModel usuarioLogado = null;

            if (login != null)
            {
                UsuarioViewModel usuario = VerificaLoginSenha(login);
                if (usuario == null)
                {
                    return usuarioLogado;
                }

                IEnumerable<OrganizacaoUsuarioMySql> organizacoes = await _organizacaoMySqlRepository.ListarOrganizacoesUsuarioEmail(usuario.Login);

                OrganizacaoUsuarioMySql organizacaoUsuario = null;

                if (organizacoes.Any(x => x.UltimaAcessada))
                    organizacaoUsuario = organizacoes?.FirstOrDefault(x => x.UsuarioPlataforma && x.UltimaAcessada);
                else
                    organizacaoUsuario = organizacoes?.FirstOrDefault(x => x.UsuarioPlataforma);

                PessoaMySql pessoa = await _pessoaMySqlRepository.BuscarPorEmail(usuario.Login);

                if (!usuario.Ativo)
                {
                    return usuarioLogado;
                }

                if (pessoa != null && !pessoa.GoobeeAdmin)
                {
                    if (organizacaoUsuario == null || !string.IsNullOrWhiteSpace(organizacaoUsuario.IdUsuario))
                    {
                        return usuarioLogado;
                    }

                    if (organizacaoUsuario.Pessoa == null || organizacaoUsuario.Pessoa.Status == false)
                    {
                        return usuarioLogado;
                    }

                    List<string> idsTimes = new List<string>();
                    foreach (var timePessoa in organizacaoUsuario.Pessoa.TimePessoas)
                    {
                        if (!timePessoa.Status)
                            continue;

                        if (timePessoa.IdOrganizacao == organizacaoUsuario.IdOrganizacao)
                            idsTimes.Add(timePessoa.IdTime);
                    }

                    usuarioLogado = new UsuarioLogadoMySqlViewModel()
                    {
                        DataCriacao = organizacaoUsuario.Pessoa.DataCriacao,
                        Email = organizacaoUsuario.Pessoa.Email,
                        Nome = organizacaoUsuario.Pessoa.Nome,
                        Foto = organizacaoUsuario.Pessoa.Foto,
                        Id = organizacaoUsuario.IdUsuario,
                        IdPessoa = organizacaoUsuario.IdPessoa,
                        IdOrganizacao = organizacaoUsuario.IdOrganizacao,
                        RoleEnum = organizacaoUsuario.OrganizacaoUsuarioRole.Role,
                        IdsTimes = idsTimes
                    };
                }
                else
                {
                    string idOrganizacao;

                    if (!string.IsNullOrWhiteSpace(pessoa.IdUltimaOrgAcessada))
                        idOrganizacao = pessoa.IdUltimaOrgAcessada;
                    else
                        idOrganizacao = _organizacaoMySqlRepository.Obter()?.Id;

                    usuarioLogado = new UsuarioLogadoMySqlViewModel()
                    {
                        DataCriacao = DateTime.Now,
                        Email = pessoa.Email,
                        Nome = pessoa.Nome,
                        Foto = pessoa.Foto,
                        Id = usuario.Id,
                        IdPessoa = pessoa.Id,
                        IdOrganizacao = idOrganizacao,
                        RoleEnum = OrganizacaoUsuarioRoleEnum.GoobeeAdmin,
                        IdsTimes = new List<string>(0)
                    };
                }
            }

            // gerar o token
            if (usuarioLogado != null)
            {
                usuarioLogado.Token = CriaToken(usuarioLogado);
            }

            return usuarioLogado;
        }

        private UsuarioViewModel VerificaLoginSenha(LoginMySql objeto)
        {
            try
            {
                UsuarioViewModel retorno = null;

                // efetuar login
                UsuarioMySql busca = _usuarioMySqlRepository.ObterUsuarioLogin(new UsuarioMySql
                {
                    Login = objeto.Usuario,
                    Senha = objeto.Senha
                });

                // objeto retorno
                retorno = new UsuarioViewModel
                {
                    Ativo = busca.Ativo,
                    ContaGoogle = busca.ContaGoogle,
                    DataCriacao = busca.DataCriacao,
                    DataEdicao = busca.DataEdicao,
                    Id = busca.Id,
                    Login = busca.Login,
                    ResponsavelCriacao = busca.ResponsavelCriacao,
                    ResponsavelEdicao = busca.ResponsavelEdicao,
                    Senha = busca.Senha,
                };

                if (busca == null)
                {
                    return retorno;
                }

                // comparar senha
                string hashGerado = CriptoHashSha256.GetSha256Hash(objeto.Senha);
                if (hashGerado == busca.Senha)
                {
                    return retorno;
                }

                return retorno;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private string CriaToken(UsuarioLogadoMySqlViewModel user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Nome));
            claims.Add(new Claim("IdOrganizacao", user.IdOrganizacao.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Birthdate, user.DataCriacao.ToString("yyyy-MM-dd")));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

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

        private async Task<bool> ValidaTokenGoogle(string idToken, UsuarioLogadoMySqlViewModel obj = null)
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


        private async Task<string> CriaToken(UsuarioLogadoMySqlViewModel usuario, string idTokenGoogle = "")
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

        private UsuarioMySql VerificaLoginGoogle(UsuarioSocialMySqlViewModel login)
        {
            return _usuarioMySqlRepository.ObterUsuarioLogin(new UsuarioMySql { Login = login.Email, ContaGoogle = true });
        }

        public async Task<UsuarioLogadoMySqlViewModel> AutenticaComGoogle(UsuarioSocialMySqlViewModel login)
        {
            UsuarioLogadoMySqlViewModel usuarioLogado = null;

            if (login != null)
            {
                UsuarioMySql usuario = VerificaLoginGoogle(login);

                if (usuario == null)
                {
                    return usuarioLogado;
                }

                if (!usuario.Ativo)
                {
                    return usuarioLogado;
                }

                if (!usuario.ContaGoogle)
                {
                    return usuarioLogado;
                }

                try
                {
                    IEnumerable<OrganizacaoUsuarioMySql> organizacoes = await _organizacaoMySqlRepository.ListarOrganizacoesUsuarioEmail(usuario.Login);

                    OrganizacaoUsuarioMySql organizacaoUsuario = null;

                    if (organizacoes.Any(x => x.UltimaAcessada))
                        organizacaoUsuario = organizacoes.FirstOrDefault(x => x.UsuarioPlataforma && x.UltimaAcessada);
                    else
                        organizacaoUsuario = organizacoes.FirstOrDefault(x => x.UsuarioPlataforma);

                    var pessoa = await _pessoaMySqlRepository.BuscarPorEmail(usuario.Login);

                    if (!usuario.Ativo)
                    {
                        return usuarioLogado;
                    }

                    if (!pessoa.GoobeeAdmin)
                    {
                        if (organizacaoUsuario == null || !string.IsNullOrWhiteSpace(organizacaoUsuario.IdUsuario))
                        {
                            return usuarioLogado;
                        }

                        if (organizacaoUsuario.Pessoa == null || organizacaoUsuario.Pessoa.Status == false)
                        {
                            return usuarioLogado;
                        }

                        List<string> idsTimes = new List<string>();
                        foreach (var timePessoa in organizacaoUsuario.Pessoa.TimePessoas)
                        {
                            if (timePessoa.IdOrganizacao == organizacaoUsuario.IdOrganizacao)
                                idsTimes.Add(timePessoa.IdTime);
                        }

                        usuarioLogado = new UsuarioLogadoMySqlViewModel()
                        {
                            DataCriacao = organizacaoUsuario.Pessoa.DataCriacao,
                            Email = organizacaoUsuario.Pessoa.Email,
                            Nome = organizacaoUsuario.Pessoa.Nome,
                            Foto = organizacaoUsuario.Pessoa.Foto,
                            Id = organizacaoUsuario.IdUsuario,
                            IdPessoa = organizacaoUsuario.IdPessoa,
                            IdOrganizacao = organizacaoUsuario.IdOrganizacao,
                            RoleEnum = organizacaoUsuario.OrganizacaoUsuarioRole.Role,
                            IdsTimes = idsTimes
                        };
                    }
                    else
                    {
                        string idOrganizacao;

                        if (!string.IsNullOrWhiteSpace(pessoa.IdUltimaOrgAcessada))
                            idOrganizacao = pessoa.IdUltimaOrgAcessada;
                        else
                            idOrganizacao = _organizacaoMySqlRepository.Obter()?.Id;

                        usuarioLogado = new UsuarioLogadoMySqlViewModel()
                        {
                            DataCriacao = DateTime.Now,
                            Email = pessoa.Email,
                            Nome = pessoa.Nome,
                            Foto = pessoa.Foto,
                            Id = usuario.Id,
                            IdPessoa = pessoa.Id,
                            IdOrganizacao = idOrganizacao,
                            RoleEnum = OrganizacaoUsuarioRoleEnum.GoobeeAdmin,
                            IdsTimes = new List<string>()
                        };
                    }

                    return usuarioLogado;
                }
                catch (Exception error)
                {
                    return usuarioLogado;
                }
            }

            if (usuarioLogado != null)
            {
                usuarioLogado.Token = await CriaToken(usuarioLogado, login.IdToken);
                if (usuarioLogado.Token == null)
                {
                    usuarioLogado = null;
                }
            }

            return usuarioLogado;
        }
    }
}
