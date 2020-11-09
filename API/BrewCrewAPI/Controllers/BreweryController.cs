﻿using System;
using Microsoft.AspNetCore.Mvc;
using BrewCrewLib;
using BrewCrewDB.Models;

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
                return Ok(_service.GetAllResources());
            }
            catch (Exception e)
            {
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
                return CreatedAtAction("AddBrewery", brewery);
            }
            catch (Exception)
            {
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
                return CreatedAtAction("UpdateBrewery", brewery);
            }
            catch (Exception)
            {
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
                return CreatedAtAction("DeleteBrewery", brewery);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}