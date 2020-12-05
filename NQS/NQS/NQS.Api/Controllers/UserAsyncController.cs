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
using System.Threading.Tasks;
using System;

namespace Leega.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserAsyncController : ControllerBase
    {
        private readonly UsuarioServico<UsuarioViewModel, Usuario> _userServiceAsync;
        public UserAsyncController(UsuarioServico<UsuarioViewModel, Usuario> userServiceAsync)
        {
            _userServiceAsync = userServiceAsync;
        }


        //get all
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var items = await _userServiceAsync.GetAll();
            return null;
        }

        //get by predicate example
        //get all active by username
        [Authorize]
        [HttpGet("GetActiveByFirstName/{firstname}")]
        public async Task<IActionResult> GetActiveByFirstName(string firstname)
        {
            return null;
            //var items = await _userServiceAsync.Get(a => a.IsActive && a.FirstName == firstname);
            //return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _userServiceAsync.GetOne(id);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", id);
                return NotFound();
            }

            return Ok(item);
        }

        //add
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserViewModel user)
        {
            if (user == null)
                return BadRequest();

            //var id = await _userServiceAsync.Add(user);
            //return Created($"api/User/{id}", id);  //HTTP201 Resource created
            return null;
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserViewModel user)
        {
            if (user == null || user.Id != id)
                return BadRequest();

            return null;
            //int retVal = await _userServiceAsync.Update(user);
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
        public async Task<IActionResult> Delete(Guid id)
        {
            int retVal = await _userServiceAsync.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}


