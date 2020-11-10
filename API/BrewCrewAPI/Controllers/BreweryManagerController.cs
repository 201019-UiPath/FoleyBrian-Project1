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
                return Ok(_service.GetAllResources());
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Get/{id}")]
        [Produces("application/json")]
        public IActionResult GetBreweryManager(string id)
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
        public IActionResult AddBreweryManager(BreweryManager breweryManager)
        {
            try
            {
                _service.AddResource(breweryManager);
                return CreatedAtAction("AddBreweryManager", breweryManager);
            }
            catch (Exception)
            {
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
                return CreatedAtAction("UpdateBreweryManager", breweryManager);
            }
            catch (Exception)
            {
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
                return CreatedAtAction("DeleteBreweryManager", breweryManager);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
