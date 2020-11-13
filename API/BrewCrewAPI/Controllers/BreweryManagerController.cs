using System;
using Serilog;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BrewCrewLib;
using BrewCrewDB.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewCrewAPI.Controllers
{
    [Route("api/brewerymanager")]
    [ApiController]
    public class ManagersJoinController : Controller
    {

        private readonly IService<BreweryManager> _service;

        public ManagersJoinController(IService<BreweryManager> service)
        {
            this._service = service;
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAllBreweryManagers()
        {
            try
            {
                List<BreweryManager> breweryManagers = _service.GetAllResources();
                Log.Information($"Successfully retrieved all brewery managers");
                return Ok(breweryManagers);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve all brewery managers - {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("Get/{id}")]
        [Produces("application/json")]
        public IActionResult GetBreweryManager(string id)
        {
            try
            {
                BreweryManager breweryManager = _service.GetResource(id);
                Log.Information($"Successfully retrieved brewery manager {id}");
                return Ok(breweryManager);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve brewery manager - {id} {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddBreweryManager(BreweryManager breweryManager)
        {
            try
            {
                _service.AddResource(breweryManager);
                Log.Information($"Successfully added brewery manager {breweryManager.ID}");
                return CreatedAtAction("AddBreweryManager", breweryManager);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to add brewery manager - {e.Message}");
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateBreweryManager(BreweryManager breweryManager)
        {
            try
            {
                _service.UpdateResource(breweryManager);
                Log.Information($"Successfully updated brewery manager {breweryManager.ID}");
                return CreatedAtAction("UpdateBreweryManager", breweryManager);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to update brewery manager - {breweryManager.ID} {e.Message}");
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteBreweryManager(BreweryManager breweryManager)
        {
            try
            {
                _service.DeleteResource(breweryManager);
                Log.Information($"Successfully deleted brewery manager {breweryManager.ID}");
                return CreatedAtAction("DeleteBreweryManager", breweryManager);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to delete brewery manager - {breweryManager.ID} {e.Message}");
                return BadRequest();
            }
        }
    }
}
