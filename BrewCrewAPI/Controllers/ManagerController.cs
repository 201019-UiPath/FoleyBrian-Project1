//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using BrewCrewLib;
//using BrewCrewDB.Models;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace BrewCrewAPI.Controllers

//{
//    [Route("[controller]")]
//    [ApiController]
//    public class ManagerController : Controller
//    {
//        private readonly IManagerService _managerService;

//        public ManagerController(IManagerService managerService)
//        {
//            this._managerService = managerService;
//        }

//        //[HttpGet("AddBeer/{breweryId}")]
//        //[Consumes("application/json")]
//        //[Produces("application/json")]
//        //public IActionResult AddBeer(Beer beer, string breweryId)
//        //{
//        //    try
//        //    {
//        //        _managerService.AddBeer(beer, breweryId);
//        //        return CreatedAtAction("AddBeer", beer, breweryId);
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        return BadRequest();
//        //    }
//        //}

//        [HttpGet("GetAllBreweries/{email}")]
//        [Produces("application/json")]
//        public IActionResult GetAllBreweries()
//        {
//            try
//            {
//                return Ok(_managerService.GetAllBreweries());
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpGet("GetAllBeersByBrewery/{breweryId}")]
//        [Produces("application/json")]
//        public IActionResult GetAllBeersByBrewery(string breweryId)
//        {
//            try
//            {
//                return Ok(_managerService.GetAllBeersByBreweryId(breweryId));
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpGet("UpdateBeer")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult UpdateBeer(Beer beer)
//        {
//            try
//            {
//                _managerService.UpdateBeer(beer);
//                return CreatedAtAction("UpdateBeer", beer);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
//        }

//        [HttpGet("GetOrderHistoryByBrewery/{breweryId}")]
//        [Produces("application/json")]
//        public IActionResult GetOrderHistoryByBrewery(string breweryId)
//        {
//            try
//            {
//                return Ok(_managerService.GetOrderHistoryByBreweryId(breweryId));
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpGet("GetBeer/{beerId}")]
//        [Produces("application/json")]
//        public IActionResult GetBeer(string beerId)
//        {
//            try
//            {
//                return Ok(_managerService.GetBeerById(beerId));
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpGet("GetCustomer/{customerId}")]
//        [Produces("application/json")]
//        public IActionResult GetCustomer(string customerId)
//        {
//            try
//            {
//                return Ok(_managerService.GetCustomerById(customerId));
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpGet("DeleteManager/{managerId}")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult DeleteManager(string managerId)
//        {
//            try
//            {
//                _managerService.DeleteManagerById(managerId);
//                return CreatedAtAction("DeleteManager", managerId);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
//        }

//        //[HttpGet("AddManager/{breweryId}")]
//        //[Consumes("application/json")]
//        //[Produces("application/json")]
//        //public IActionResult AddManager(User manager, string breweryId)
//        //{
//        //    try
//        //    {
//        //        _managerService.AddManager(manager, breweryId);
//        //        return CreatedAtAction("DeleteManagerById", manager, breweryId);
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        return BadRequest();
//        //    }
//        //}

//        [HttpGet("GetBreweryByManager/{managerId}")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult GetBreweryByManager(string managerId)
//        {
//            try
//            {
//                _managerService.GetBreweryByManagerId(managerId);
//                return CreatedAtAction("GetBreweryByManager", managerId);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
//        }
//    }
//}
