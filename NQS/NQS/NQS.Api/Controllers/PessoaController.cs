using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpAwsS3ServiceManager.AwsS3;
using Leega.Domain;
using Leega.Domain.Service;
using Leega.Domain.Utils;
using Leega.Entity;
using Leega.Entity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leega.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService<PessoaViewModel, Pessoa> _pessoaService;
        //private readonly TimeService<TimeViewModel, Time> _timeService;
        private readonly ClienteService<ClienteViewModel, Cliente> _clienteService;
        //private readonly HabilidadeService<HabilidadeViewModel, Habilidade> _habilidadeService;
        private readonly IAwsS3HelperService _awsS3Service;
        private Guid _idOrganizacao { get; set; }
        private OrganizacaoUsuarioRoleEnum _roleEnum { get; set; }

        public PessoaController(PessoaService<PessoaViewModel, Pessoa> pessoaService,
                                //TimeService<TimeViewModel, Time> timeService,
                                ClienteService<ClienteViewModel, Cliente> clienteService,
                                //HabilidadeService<HabilidadeViewModel, Habilidade> habilidadeService,
                                IAwsS3HelperService awsS3Service,
                                IHttpContextAccessor contextAccessor)
        {
            _pessoaService = pessoaService;
            //_timeService = timeService;
            _clienteService = clienteService;
            //_habilidadeService = habilidadeService;
            _awsS3Service = awsS3Service;


            _idOrganizacao = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");// Guid(contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "IdOrganizacao")?.Value);
            _roleEnum = OrganizacaoUsuarioRoleEnum.GoobeeAdmin; // (OrganizacaoUsuarioRoleEnum)Enum.Parse(typeof(OrganizacaoUsuarioRoleEnum), contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "RoleEnum")?.Value);
        }

        [Authorize(Roles = RolesNomes.Todos)]
        [HttpGet("PessoasAtivas/{idPessoa?}")]
        public async Task<IActionResult> ListarUsuariosAtivos(Guid? idPessoa)
        {
            var pessoasAtivas = await _pessoaService.ListarUsuariosAtivos(idPessoa, _idOrganizacao);

            return Ok(pessoasAtivas);
        }

        //add
        //[Authorize(Roles = "Administrator")]
        //[Authorize(Roles = RolesNomes.Admins + "," + RolesNomes.AgileCoach_TeamLeader)]
        [HttpPost("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] PessoaAdicionarViewModel pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (pessoa == null)
                return BadRequest();

            var pessoaResposta = await _pessoaService.AdicionarPessoa(pessoa, _idOrganizacao);

            if (pessoaResposta == null)
            {
                return StatusCode(500, "Erro ao adicionar pessoa!");
            }
            if (pessoaResposta.ExibicaoMensagem != null)
            {
                return StatusCode(pessoaResposta.ExibicaoMensagem.StatusCode, pessoaResposta);
            }

            if (!String.IsNullOrEmpty(pessoa.Pessoa.Foto) && pessoa.Pessoa.Foto.Contains("base64"))
            {
                var nomeArquivo = $"pessoa-{pessoaResposta.Objeto}";
                var sucesso = await _awsS3Service.UploadFileAsync(pessoa.Pessoa.Foto, nomeArquivo, null);
                var urlImagem = $"{Environment.GetEnvironmentVariable("PROTOCOLO_URL")}://{HttpContext.Request.Host}/api/AwsS3?nomeArquivo={nomeArquivo}";
                if (sucesso)
                    await _pessoaService.AtualizarFoto(pessoaResposta.Objeto, urlImagem, _idOrganizacao);
            }

            return Ok(pessoaResposta);
        }

        //[Authorize(Roles = RolesNomes.Admins + "," + RolesNomes.AgileCoach_TeamLeader)]
        //[HttpPost("ConvidarNovamente")]
        //public async Task<IActionResult> ConvidarNovamente([FromBody] ConvidadarNovamenteViewModel convidarNovamente)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    var resposta = await _pessoaService.ConvidarNovamente(convidarNovamente, _idOrganizacao);

        //    if (!resposta)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }

        //    return Ok();
        //    //return Created($"api/Usuario/{id}", id);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        [HttpPost("ListarTodas")]
        public async Task<IActionResult> ListarTodas([FromBody] FiltrosListarPessoasViewModel filtros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pessoas = await _pessoaService.ListarTodas(filtros, _idOrganizacao, _roleEnum);

            return Ok(pessoas);
        }

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarPerfil/{id}")]
        //public async Task<IActionResult> PegarPerfil(Guid id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var pessoas = await _pessoaService.PegarPerfil(id, _idOrganizacao);

        //    return Ok(pessoas);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        [HttpGet("PegarEditarPerfil/{id}")]
        public async Task<IActionResult> PegarEditarPerfil(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pessoas = await _pessoaService.PegarEditarPerfil(id, _idOrganizacao);

            return Ok(pessoas);
        }

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpPut("EditarPerfil/{id}")]
        //public async Task<IActionResult> EditarPerfil(Guid id, [FromBody] PerfilEditarViewModel pessoa)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    if (pessoa == null || pessoa.Id != id)
        //        return BadRequest();

        //    if (!String.IsNullOrEmpty(pessoa.Foto) && pessoa.Foto.Contains("base64"))
        //    {
        //        var nomeArquivo = $"pessoa-{pessoa.Id}";
        //        var sucesso = await _awsS3Service.UploadFileAsync(pessoa.Foto, nomeArquivo, null);
        //        var urlImagem = $"{Environment.GetEnvironmentVariable("PROTOCOLO_URL")}://{HttpContext.Request.Host}/api/AwsS3?nomeArquivo={nomeArquivo}";
        //        pessoa.Foto = sucesso ? urlImagem : "";
        //    }

        //    var retorno = await _pessoaService.EditarPerfil(pessoa, _idOrganizacao, _roleEnum);

        //    if (retorno.ExibicaoMensagem != null)
        //    {
        //        return StatusCode(retorno.ExibicaoMensagem.StatusCode, retorno);
        //    }

        //    return Ok(retorno.Objeto);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarTimePerfil/{idPerfil}/{idPessoaLogada}")]
        //public async Task<IActionResult> PegarTimePerfil(Guid idPerfil, Guid idPessoaLogada)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var timesPerfil = await _pessoaService.PegarTimePerfil(idPerfil, idPessoaLogada, _idOrganizacao);

        //    return Ok(timesPerfil);
        //}

        //[Authorize(Roles = RolesNomes.Admins + "," + RolesNomes.AgileCoach_TeamLeader)]
        [HttpPut("EditarTimePerfil/{id}")]
        public async Task<IActionResult> EditarTimePerfil(Guid id, [FromBody] EditarTimePerfilViewModel timesPessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (timesPessoa == null || timesPessoa.IdPessoa != id)
                return BadRequest();

            var retorno = await _pessoaService.EditarTimePerfil(timesPessoa, _idOrganizacao);

            if (retorno.ExibicaoMensagem != null)
            {
                return StatusCode(retorno.ExibicaoMensagem.StatusCode, retorno);
            }

            return Ok(retorno);
        }

        //[Authorize(Roles = RolesNomes.Todos)]
        [HttpGet("PegarClientePerfil/{id}")]
        public async Task<IActionResult> PegarClientePerfil(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var clientesPerfil = await _pessoaService.PegarClientePerfil(id, _idOrganizacao);

            return Ok(clientesPerfil);
        }

        [Authorize(Roles = RolesNomes.Admins + "," + RolesNomes.AgileCoach_TeamLeader)]
        [HttpPut("EditarClientePerfil/{id}")]
        public async Task<IActionResult> EditarClientePerfil(Guid id, [FromBody] EditarClientePerfilViewModel clientesPessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (clientesPessoa == null || clientesPessoa.IdPessoa != id)
                return BadRequest();

            var retorno = await _pessoaService.EditarClientePerfil(clientesPessoa, _idOrganizacao);

            if (retorno.ExibicaoMensagem != null)
            {
                return StatusCode(retorno.ExibicaoMensagem.StatusCode, retorno);
            }

            return Ok(retorno);
        }

        [Authorize(Roles = RolesNomes.Todos)]
        [HttpGet("HistoricoClientesPessoa/{id}")]
        public async Task<IActionResult> HistoricoClientesPessoa(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var clientesPessoa = await _pessoaService.HistoricoClientesPessoa(id, _idOrganizacao);

            return Ok(clientesPessoa);
        }

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpPost("AdicionaAcaoColaborador")]
        //public async Task<IActionResult> AdicionaAcaoColaborador([FromBody] AcaoViewModel acao)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    if (acao == null)
        //        return BadRequest();

        //    var id = await _pessoaService.AdicionaAcao(acao, _idOrganizacao);

        //    return Created($"api/Time/{id}", id);  //HTTP201 Resource created
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("ListarAcaoColaborador/{id}")]
        //public async Task<IActionResult> ListarAcaoColaborador(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }

        //    var lista = await _pessoaService.ListarAcoes(id, _idOrganizacao);
        //    return Ok(lista);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarAcaoColaborador/{idColaborador}/{idAcao}")]
        //public async Task<IActionResult> PegarAcaoColaborador(Guid idColaborador, Guid idAcao)
        //{
        //    if (idColaborador == null || idAcao == null)
        //    {
        //        return BadRequest();
        //    }

        //    var resultado = await _pessoaService.PegarAcaoColaborador(idColaborador, idAcao, _idOrganizacao);

        //    if (resultado == null)
        //    {
        //        return Conflict();
        //    }

        //    return Ok(resultado);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpPut("EditarAcaoColaborador")]
        //public async Task<IActionResult> EditarAcaoColaborador([FromBody]ListaAcaoColaboradorViewModel acao)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var resultado = await _pessoaService.EditarAcaoColaborador(acao, _idOrganizacao);

        //    if (resultado == Guid.Empty)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(resultado);
        //}


        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpDelete("DeletarAcaoColaborador/{id}")]
        //public async Task<IActionResult> RemoverAcao(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }

        //    var resultado = await _pessoaService.DeletarAcaoColaborador(id);
        //    if (resultado == Guid.Empty)
        //    {
        //        return Conflict();
        //    }

        //    return Ok();
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("ListaMembrosDoMesmoTime/{id}")]
        //public async Task<IActionResult> ListaMembrosDoMesmoTime(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }

        //    var lista = await _pessoaService.ListaMembrosMesmoTime(id, _idOrganizacao);
        //    return Ok(lista);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarTimesComboBox")]
        //public async Task<IActionResult> PegarTimesComboBox()
        //{
        //    var lista = await _timeService.PegarTimesComboBox(_idOrganizacao);

        //    return Ok(lista);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarClientesComboBox")]
        //public async Task<IActionResult> PegarClientesComboBox()
        //{
        //    var lista = await _clienteService.PegarClientesComboBox(_idOrganizacao);

        //    return Ok(lista);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarResponsaveisComboBox")]
        //public async Task<IActionResult> PegarResponsaveisComboBox()
        //{
        //    var lista = await _pessoaService.PegarResponsaveisComboBox(_idOrganizacao);

        //    return Ok(lista);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarPessoasUsuarioNaoInclusivo/{idPessoa}")]
        //public async Task<IActionResult> PegarPessoasUsuarioNaoInclusivo(Guid idPessoa)
        //{
        //    var lista = await _pessoaService.PegarPessoasUsuarioNaoInclusivo(idPessoa, _idOrganizacao);

        //    return Ok(lista);
        //}

        [Authorize(Roles = RolesNomes.Todos)]
        [HttpPost("AdicionarPersonalMapping")]
        public async Task<IActionResult> AdicionarPersonalMapping([FromBody] AdicionarPersonalMappingViewModel personalMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (personalMapping == null)
                return BadRequest();

            var retorno = await _pessoaService.AdicionarPersonalMapping(personalMapping, _idOrganizacao, _roleEnum);

            if (retorno.ExibicaoMensagem != null)
            {
                return StatusCode(retorno.ExibicaoMensagem.StatusCode, retorno);
            }

            return Created($"api/Time/{retorno.Objeto}", retorno.Objeto);  //HTTP201 Resource created
        }

        //[Authorize(Roles = RolesNomes.Todos)]
        [HttpGet("PegarPersonalMapping/{id}")]
        public async Task<IActionResult> PegarPersonalMapping(Guid id)
        {
            var lista = await _pessoaService.PegarPersonalMapping(id, _idOrganizacao);

            return Ok(lista);
        }

        //[Authorize(Roles = RolesNomes.Todos)]
        [HttpPut("EditarPersonalMapping/{id}")]
        public async Task<IActionResult> EditarPersonalMapping(Guid id, [FromBody] EditarPersonalMappingViewModel personalMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (personalMapping == null || personalMapping.IdPessoa != id)
                return BadRequest();

            var retorno = await _pessoaService.EditarPersonalMapping(personalMapping, _idOrganizacao, _roleEnum);

            if (retorno.ExibicaoMensagem != null)
            {
                return StatusCode(retorno.ExibicaoMensagem.StatusCode, retorno);
            }

            return Ok(retorno);
        }

        //[Authorize(Roles = RolesNomes.Todos)]
        [HttpDelete("DeletarPersonalMapping/{id}")]
        public async Task<IActionResult> DeletarPersonalMapping(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var retorno = await _pessoaService.DeletarPersonalMapping(id);

            if (!retorno)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpPost("AdicionarHabilidade")]
        //public async Task<IActionResult> AdicionarHabilidade([FromBody] AdicionarHabilidadeViewModel adicionarHabilidade)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    if (adicionarHabilidade == null)
        //        return BadRequest();

        //    var retorno = await _pessoaService.AdicionarHabilidade(adicionarHabilidade, _idOrganizacao);

        //    if (retorno == null)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }

        //    return Ok(retorno);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarHabilidadesComboBox/{idPessoa}")]
        //public async Task<IActionResult> PegarHabilidadesComboBox(Guid idPessoa)
        //{
        //    var lista = await _habilidadeService.PegarHabilidadesComboBox(idPessoa, _idOrganizacao);

        //    return Ok(lista);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarHabilidades/{idPessoa}")]
        //public async Task<IActionResult> PegarHabilidades(Guid idPessoa)
        //{
        //    var lista = await _habilidadeService.PegarHabilidades(idPessoa, _idOrganizacao);

        //    return Ok(lista);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarTodasHabilidades")]
        //public async Task<IActionResult> PegarTodasHabilidades()
        //{
        //    var lista = await _habilidadeService.PegarTodasHabilidades(_idOrganizacao);

        //    return Ok(lista);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpDelete("RemoverHabilidade/{id}")]
        //public async Task<IActionResult> RemoverHabilidade(Guid id, [FromBody] RemoverHabilidadeViewModel removerHabilidade)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    if (id != removerHabilidade.IdPessoa)
        //    {
        //        return BadRequest();
        //    }

        //    var retorno = await _pessoaService.RemoverHabilidade(removerHabilidade, _idOrganizacao);

        //    if (!retorno)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }

        //    return Ok();
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpGet("PegarMotivadores/{idPessoa}")]
        //public async Task<IActionResult> PegarMotivadores(Guid idPessoa)
        //{
        //    var lista = await _pessoaService.PegarMotivadores(idPessoa, _idOrganizacao);

        //    return Ok(lista);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpPost("AdicionarMotivadores")]
        //public async Task<IActionResult> AdicionarMotivadores([FromBody] AdicionarMotivadoresViewModel adicionarMotivadores)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    if (adicionarMotivadores == null)
        //        return BadRequest();

        //    var retorno = await _pessoaService.AdicionarMotivadores(adicionarMotivadores, _idOrganizacao, _roleEnum);

        //    if (retorno == Guid.Empty)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }

        //    return Ok(retorno);
        //}

        //[Authorize(Roles = RolesNomes.Todos)]
        //[HttpPut("EditarMotivadores/{idPessoa}")]
        //public async Task<IActionResult> EditarMotivadores(Guid idPessoa, [FromBody] EditarMotivadoresViewModel motivadoresEditados)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    if (motivadoresEditados == null || motivadoresEditados.IdPessoa != idPessoa)
        //        return BadRequest();

        //    var retorno = await _pessoaService.EditarMotivadores(motivadoresEditados, _idOrganizacao, _roleEnum);

        //    if (!retorno)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }

        //    return Ok();
        //}
    }
}