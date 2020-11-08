using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewCrewDB;
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
    }
}
