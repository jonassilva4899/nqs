using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leega.Domain;
using Leega.Domain.Service;
using Leega.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leega.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService<ClienteViewModel, Cliente> _clienteService;
        private Guid _idOrganizacao { get; set; }

        public ClienteController(ClienteService<ClienteViewModel, Cliente> clienteService,
            IHttpContextAccessor contextAccessor)
        {
            _clienteService = clienteService;
            _idOrganizacao = new Guid(contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "IdOrganizacao")?.Value);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (cliente == null)
                return BadRequest();

            cliente.IdOrganizacao = _idOrganizacao;

            var id = await _clienteService.Criar(cliente);

            return Created($"api/Time/{id}", id);  //HTTP201 Resource created
        }

        //[Authorize]
        [HttpPost("AdicionarCliente")]
        public async Task<IActionResult> AdicionarCliente([FromBody] ClienteAdicionarViewModel clienteAdicionar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (clienteAdicionar == null)
            {
                return BadRequest();
            }

            var id = await _clienteService.AdicionarCliente(clienteAdicionar, _idOrganizacao);

            if (id != null)
            {
                return Created($"api/Time/{id}", id);  //HTTP201 Resource created
            }
            else
            {
                return Conflict();
            }
        }


        [Authorize]
        [HttpPost("AdicionarClienteFake")]
        public async Task<IActionResult> AdicionarClienteFake(AdicionarClienteFakeViewModel clienteAdicionar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (clienteAdicionar == null)
            {
                return BadRequest();
            }

            //var id = await _clienteService.AdicionarCliente(clienteAdicionar, _idOrganizacao);

            //if (id != null)
            //{
            //    return Created($"api/Time/{id}", id);  //HTTP201 Resource created
            //}
            //else
            //{
                return Conflict();
            //}
        }

        [Authorize]
        [HttpPut("EditarCliente")]
        public async Task<IActionResult> EditarCliente([FromBody] PessoaClienteViewModel clienteEditar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (clienteEditar == null)
            {
                return BadRequest();
            }

            clienteEditar.IdOrganizacao = _idOrganizacao;
            var id = await _clienteService.EditarCliente(clienteEditar);

            if(id != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}