using System;
using Microsoft.AspNetCore.Mvc;
using BrewCrewDB.Models;
using BrewCrewLib;
using Serilog;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewCrewAPI.Controllers
{
    [Route("api/beer")]
    [ApiController]
    public class BeerController : Controller
    {
        private readonly IService<Beer> _service;

        public BeerController(IService<Beer> service)
        {
            this._service = service;
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAllBeers()
        {
            try
            {
                List<Beer> beers = _service.GetAllResources();
                Log.Information($"Successfully retrieved all beers");
                return Ok(beers);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve all beers - {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("Get/{id}")]
        [Produces("application/json")]
        public IActionResult GetBeer(string id)
        {
            try
            {
                Beer beer = _service.GetResource(id);
                Log.Information($"Successfully retrieved beer {beer.ID}");
                return Ok(beer);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve beer - {id} {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("Get/Brewery/{id}")]
        [Produces("application/json")]
        public IActionResult GetBeersByBreweryId(string id)
        {
            try
            {
                List<Beer> beer = _service.GetAllBeersByBreweryId(id);
                Log.Information($"Successfully retrieved beers by brewery Id {id}");
                return Ok(beer);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve beer - {id} {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddBeer(Beer beer)
        {
            try
            {
                _service.AddResource(beer);
                Log.Information($"Successfully added beer {beer.ID}");
                return CreatedAtAction("AddBeer", beer);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to add beer - {beer.ID} {e.Message}");
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateBeer(Beer beer)
        {
            try
            {
                _service.UpdateResource(beer);
                Log.Information($"Successfully updated beer {beer.ID}");
                return CreatedAtAction("UpdateBeer", beer);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to update beer - {beer.ID} {e.Message}");
                return BadRequest();
            }
        }

        [HttpDelete("Delete/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteBeer(string id)
        {
            try
            {
                _service.DeleteResource(id);
                Log.Information($"Successfully deleted beer {id}");
                return CreatedAtAction("DeleteBeer", id);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to delete beer - {id} {e.Message}");
                return BadRequest();
            }
        }
    }
}
