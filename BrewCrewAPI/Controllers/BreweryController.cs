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
    [Route("api/brewery")]
    [ApiController]
    public class BreweryController : Controller
    {

        private readonly IService _service;

        public BreweryController(IService service)
        {
            this._service = service;
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAllBreweries()
        {
            try
            {
                return Ok(_service.GetAllBreweries());
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
