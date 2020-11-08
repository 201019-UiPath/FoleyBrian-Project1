using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewCrewLib;
using BrewCrewDB.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewCrewAPI.Controllers
{
    [Route("api/beer")]
    [ApiController]
    public class BeerItemController : Controller
    {
        private readonly IService _service;

        public BeerItemController(IService service)
        {
            this._service = service;
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAllBeerItems()
        {
            try
            {
                return Ok(_service.GetAllBeerItems());
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddBeerItem(BeerItem beeritem)
        {
            try
            {
                _service.AddBeerItem(beeritem);
                return CreatedAtAction("AddBeerItem", beeritem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateBeerItem(BeerItem beeritem)
        {
            try
            {
                _service.UpdateBeerItem(beeritem);
                return CreatedAtAction("UpdateBeerItem", beeritem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteBeerItem(BeerItem beeritem)
        {
            try
            {
                _service.DeleteBeerItem(beeritem);
                return CreatedAtAction("DeleteBeer", beeritem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
   
}
