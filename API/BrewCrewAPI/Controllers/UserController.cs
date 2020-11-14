using System;
using Microsoft.AspNetCore.Mvc;
using BrewCrewLib;
using BrewCrewDB.Models;
using Serilog;
using System.Collections.Generic;

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
                List<User> users = _service.GetAllResources();
                Log.Information($"Successfully retrieved all users");
                return Ok(users);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve all users - {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("GetAll/Type/{type}")]
        [Produces("application/json")]
        public IActionResult GetAllUsersByType(string type)
        {
            try
            {
                List<User> users = _service.GetAllUsersByType(type);
                Log.Information($"Successfully retrieved all users by type: {type}");
                return Ok(users);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve user by type - {type} {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("Get/{id}")]
        [Produces("application/json")]
        public IActionResult GetUser(string id)
        {
            try
            {
                User user = _service.GetResource(id);
                Log.Information($"Successfully retrieved user {user.ID}");
                return Ok(user);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve user - {id} {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("Get/Login/{email}")]
        [Produces("application/json")]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                User user = _service.GetUserByEmail(email);
                Log.Information($"Successfully retrieved user {user.ID}");
                return Ok(user);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve user by email - {email} {e.Message}");
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
                Log.Information($"Successfully added user {user.ID}");
                return CreatedAtAction("AddUser", user);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to add user - {user.ID} : {e.Message}");
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
                Log.Information($"Successfully updated user {user.ID}");
                return CreatedAtAction("UpdateUser", user);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to update user - {user.ID} : {e.Message}");
                return BadRequest();
            }
        }

        [HttpDelete("Delete/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                _service.DeleteResource(id);
                Log.Information($"Successfully deleted user {id}");
                return CreatedAtAction("DeleteUser", id);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to delete user - {id} : {e.Message} ");
                return BadRequest();
            }
        }
    }
}
