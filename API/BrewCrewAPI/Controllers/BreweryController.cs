using System;
using Microsoft.AspNetCore.Mvc;
using BrewCrewLib;
using BrewCrewDB.Models;
using Serilog;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewCrewAPI.Controllers
{
    [Route("api/brewery")]
    [ApiController]
    public class BreweryController : Controller
    {

        private readonly IService<Brewery> _service;

        public BreweryController(IService<Brewery> service)
        {
            this._service = service;
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAllBreweries()
        {
            try
            {
                List<Brewery> breweries = _service.GetAllResources();
                Log.Information($"Successfully retrieved all breweries");
                return Ok(breweries);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve all breweries - {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("Get/{id}")]
        [Produces("application/json")]
        public IActionResult GetBrewery(string id)
        {
            try
            {
                Brewery brewery = _service.GetResource(id);
                Log.Information($"Successfully retrieved brewery {id}");
                return Ok(brewery);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve brewery - {id} {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddBrewery(Brewery brewery)
        {
            try
            {
                _service.AddResource(brewery);
                Log.Information($"Successfully added brewery {brewery.ID}");
                return CreatedAtAction("AddBrewery", brewery);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to add brewery - {brewery.ID} {e.Message}");
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateBrewery(Brewery brewery)
        {
            try
            {
                _service.UpdateResource(brewery);
                Log.Information($"Successfully updated brewery {brewery.ID}");
                return CreatedAtAction("UpdateBrewery", brewery);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to update brewery - {brewery.ID} {e.Message}");
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteBrewery(Brewery brewery)
        {
            try
            {
                _service.DeleteResource(brewery);
                Log.Information($"Successfully deleted brewery {brewery.ID}");
                return CreatedAtAction("DeleteBrewery", brewery);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to delete brewery - {brewery.ID} {e.Message}");
                return BadRequest();
            }
        }
    }
}
