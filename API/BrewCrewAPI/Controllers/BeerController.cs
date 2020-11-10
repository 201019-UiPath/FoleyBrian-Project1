using System;
using Microsoft.AspNetCore.Mvc;
using BrewCrewDB.Models;
using BrewCrewLib;

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
                return Ok(_service.GetAllResources());
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Get/{id}")]
        [Produces("application/json")]
        public IActionResult GetBeer(string id)
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

        [HttpPost("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddBeer(Beer beer)
        {
            try
            {
                _service.AddResource(beer);
                return CreatedAtAction("AddBeer", beer);
            }
            catch (Exception)
            {
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
                return CreatedAtAction("UpdateBeer", beer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteBeer(Beer beer)
        {
            try
            {
                _service.DeleteResource(beer);
                return CreatedAtAction("DeleteBeer", beer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
