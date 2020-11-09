using System;
using Microsoft.AspNetCore.Mvc;
using BrewCrewLib;
using BrewCrewDB.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewCrewAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IService<User> _service;

        public CustomerController(IService<User> service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_service.GetAllResources());
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetAll/{identifier}")]
        [Produces("application/json")]
        public IActionResult GetAllUsersByIdentifier(string identifier)
        {
            try
            {
                return Ok(_service.GetAllResources(identifier));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddUser(User user)
        {
            try
            {
                _service.AddResource(user);
                return CreatedAtAction("AddUser", user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                _service.UpdateResource(user);
                return CreatedAtAction("UpdateUser", user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteUser(User user)
        {
            try
            {
                _service.DeleteResource(user);
                return CreatedAtAction("DeleteUser", user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
