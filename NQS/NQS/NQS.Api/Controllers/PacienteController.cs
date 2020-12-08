using Leega.Application.Interfaces;
using Leega.Application.ViewModels;
using Leega.DataMySql.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Leega.Api.Controllers
{
    
    [Route("[controller]")]    
    [ApiController]
    public class PacienteController : Controller
    {
        private readonly IPacienteMySqlService _pacienteMySqlService;
        public PacienteController(IPacienteMySqlService pacienteMySqlService)
        {
            _pacienteMySqlService = pacienteMySqlService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost, Route("Adicionar")]
        //public async Task<IActionResult> Adicionar([FromBody] PacienteMySql objpaciente)
        public IActionResult Adicionar([FromBody] PacienteMySql objpaciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (objpaciente == null)
                return BadRequest();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                
                _pacienteMySqlService.Adicionar(objpaciente);                

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        
        [HttpGet("ListarPacientes/{id?}")]
        public async Task<IActionResult> ListarPacientes(Guid? id)
        {
            var pessoasAtivas = await _pacienteMySqlService.ListarUsuariosAtivos(idPessoa, _idOrganizacao);

            return Ok(pessoasAtivas);
        }
    }
}
