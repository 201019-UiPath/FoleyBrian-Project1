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

        [HttpGet("GetAll/Type/{type}")]
        [Produces("application/json")]
        public IActionResult GetAllUsersByType(string type)
        {
            try
            {
                return Ok(_service.GetAllUsersByType(type));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Get/{id}")]
        [Produces("application/json")]
        public IActionResult GetUser(string id)
        {
            try
            {
                return Ok(_service.GetResource(id));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Get/Login/{email}")]
        [Produces("application/json")]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                return Ok(_service.GetUserByEmail(email));
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
