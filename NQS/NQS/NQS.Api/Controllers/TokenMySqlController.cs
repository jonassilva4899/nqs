using Leega.Application.Interfaces;
using Leega.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leega.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/login-mysql")]
    [ApiController]
    public class TokenMySqlController : Controller
    {
        private readonly ILoginMySqlService _loginMySqlService;
        public TokenMySqlController(ILoginMySqlService loginMySqlService)
        {
            _loginMySqlService = loginMySqlService;
        }

        [AllowAnonymous]
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginMySql login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                UsuarioLogadoMySqlViewModel usuario = await _loginMySqlService.Autentica(login);
                if (usuario == null)
                {
                    return Unauthorized();
                }

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost(), Route("logincomgoogle")]
        public async Task<IActionResult> LoginComGoogle([FromBody] UsuarioSocialMySqlViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            UsuarioLogadoMySqlViewModel usuarioLogado = await _loginMySqlService.AutenticaComGoogle(usuario);
            if (usuarioLogado != null)
            {
                return Ok(usuarioLogado);
            }

            return Unauthorized();
        }
    }
}
