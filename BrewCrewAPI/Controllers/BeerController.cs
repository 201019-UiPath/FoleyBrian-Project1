﻿using System;
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
        private readonly IService _service;

        public BeerController(IService service)
        {
            this._service = service;
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAllBeers()
        {
            try
            {
                return Ok(_service.GetAllBeers());
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
                _service.AddBeer(beer);
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
                _service.UpdateBeer(beer);
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
                _service.DeleteBeer(beer);
                return CreatedAtAction("DeleteBeer", beer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
