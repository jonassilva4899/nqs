using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leega.Domain;
using Leega.Domain.Domain;
using Leega.Domain.Service;
using Leega.Entity;
using Leega.Entity.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leega.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginServico<UsuarioViewModel, Usuario> _loginService;

        public LoginController(LoginServico<UsuarioViewModel, Usuario> loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> InserirSenha([FromBody] InserirSenhaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (modelo.NovaSenha != modelo.ConfirmacaoNovaSenha)
            {
                return BadRequest();
            }

            var resposta = await _loginService.InserirSenha(modelo);

            return Ok(resposta);
        }

        [HttpPost("RecuperarSenha")]
        public async Task<IActionResult> RecuperarSenha([FromBody] RecebeEmailViewModel email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var recuperarSenhaResposta = await _loginService.RecuperarSenha(email);

            if (recuperarSenhaResposta.ExibicaoMensagem != null)
            {
                return StatusCode(recuperarSenhaResposta.ExibicaoMensagem.StatusCode, recuperarSenhaResposta);
            }

            return Ok(recuperarSenhaResposta);
        }

        [HttpPost("ValidarRecuperarSenha")]
        public async Task<IActionResult> ValidarRecuperarSenha([FromBody] SenhasHashsViewModel senhasHashsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var resultado = await _loginService.ValidarRestaurarSenha(senhasHashsViewModel);

            if (resultado.ExibicaoMensagem != null)
            {
                return StatusCode(resultado.ExibicaoMensagem.StatusCode, resultado);
            }

            return Ok(resultado);
        }
    }
}