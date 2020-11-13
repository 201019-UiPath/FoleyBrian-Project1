//using System;
//using Serilog;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using BrewCrewLib;
//using BrewCrewDB.Models;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace BrewCrewAPI.Controllers
//{
//    [Route("api/beeritem")]
//    [ApiController]
//    public class BeerItemController : Controller
//    {
//        private readonly IService<BeerItem> _service;

//        public BeerItemController(IService<BeerItem> service)
//        {
//            this._service = service;
//        }

//        [HttpGet("GetAll")]
//        [Produces("application/json")]
//        public IActionResult GetAllBeerItems()
//        {
//            try
//            {
//                List<BeerItem> beeritems = _service.GetAllResources();
//                Log.Information($"Successfully retrieved all beer items");
//                return Ok();
//            }
//            catch (Exception e)
//            {
//                Log.Warning($"Unable to retrieve all beer items - {e.Message}");
//                return StatusCode(500);
//            }
//        }

//        [HttpGet("Get/{id}")]
//        [Produces("application/json")]
//        public IActionResult GetBeerItem(string id)
//        {
//            try
//            {
//                BeerItem beerItem = _service.GetResource(id);
//                Log.Information($"Successfully retrieved beer item {id}");
//                return Ok(beerItem);
//            }
//            catch (Exception e)
//            {
//                Log.Warning($"Unable to retrieve beer - {id} {e.Message}");
//                return StatusCode(500);
//            }
//        }

//        [HttpPost("Add")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult AddBeerItem(BeerItem beeritem)
//        {
//            try
//            {
//                _service.AddResource(beeritem);
//                Log.Information($"Successfully added beer item {beeritem.ID}");
//                return CreatedAtAction("AddBeerItem", beeritem);
//            }
//            catch (Exception e)
//            {
//                Log.Warning($"Unable to add beer item - {beeritem.ID} {e.Message}");
//                return BadRequest();
//            }
//        }

//        [HttpPut("Update")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult UpdateBeerItem(BeerItem beeritem)
//        {
//            try
//            {
//                _service.UpdateResource(beeritem);
//                Log.Information($"Successfully update beer item {beeritem.ID}");
//                return CreatedAtAction("UpdateBeerItem", beeritem);
//            }
//            catch (Exception e)
//            {
//                Log.Warning($"Unable to update beer item - {beeritem.ID} {e.Message}");
//                return BadRequest();
//            }
//        }

//        [HttpDelete("Delete")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult DeleteBeerItem(BeerItem beeritem)
//        {
//            try
//            {
//                _service.DeleteResource(beeritem);
//                Log.Information($"Successfully deleted beer item {beeritem.ID}");
//                return CreatedAtAction("DeleteBeer", beeritem);
//            }
//            catch (Exception e)
//            {
//                Log.Warning($"Unable to delete beer item - {beeritem.ID} {e.Message}");
//                return BadRequest();
//            }
//        }
//    }

//}
