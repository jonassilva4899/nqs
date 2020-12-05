using System;
using System.Threading.Tasks;
using Leega.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Leega.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiPublicaController : ControllerBase
    {
        private readonly ApiPublicaService _apiPublicaService;
        public ApiPublicaController(ApiPublicaService apiPublicaService)
        {
            _apiPublicaService = apiPublicaService;
        }

        [HttpGet("v1/Organizacoes")]
        public async Task<IActionResult> Get([FromQuery] string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Um token de autenticação deve ser informado");
                }

                var validadeToken = await _apiPublicaService.ValidarTokenOtp(token);

                if (!validadeToken)
                    return BadRequest("Token inválido");

                var organizacoes = await _apiPublicaService.ListarOrganizacoes();

                return Ok(organizacoes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}