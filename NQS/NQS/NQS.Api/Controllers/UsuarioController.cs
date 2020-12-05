using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Leega.Domain;
using Leega.Entity.Context;
using Leega.Domain.Service;
using Microsoft.Extensions.Logging;
using Serilog;
using Leega.Entity;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Leega.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServico<UsuarioViewModel, Usuario> _usuarioServico;
        private Guid _idOrganizacao { get; set; }
        
        public UsuarioController(UsuarioServico<UsuarioViewModel, Usuario> usuarioServico,
            IHttpContextAccessor contextAccessor)
        {
            _usuarioServico = usuarioServico;
            _idOrganizacao = new Guid(contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "IdOrganizacao")?.Value);
        }

        //get all
        [Authorize]
        [HttpGet]
        public IEnumerable<UsuarioViewModel> GetAll()
        {
            //var items = _userService.GetAll();
            return null;
        }

        //get by predicate example
        //get all active by username
        [Authorize]
        [HttpGet("GetActiveByFirstName/{firstname}")]
        public IActionResult GetActiveByFirstName(string firstname)
        {
            return null;
            //var items = _userService.Get(a => a.IsActive && a.FirstName == firstname);
            //return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            //var item = _userService.GetOne(id);
            //if (item == null)
            //{
            //    Log.Error("GetById({ ID}) NOT FOUND", id);
            //    return NotFound();
            //}

            //return Ok(item);
            return null;
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UserViewModel user)
        {
            if (user == null || user.Id != id)
                return BadRequest();
            return null;

            //int retVal = _userService.Update(user);
            //if (retVal == 0)
            //    return StatusCode(304);  //Not Modified
            //else if (retVal == -1)
            //    return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            //else
            //    return Accepted(user);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return null;

            //int retVal = _userService.Remove(id);
            //if (retVal == 0)
            //    return NotFound();  //Not Found 404
            //else if (retVal == -1)
            //    return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            //else
            //    return NoContent();   	     //No Content 204
        }
    }
}


