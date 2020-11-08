//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using BrewCrewDB;
//using BrewCrewLib;
//using BrewCrewDB.Models;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace BrewCrewAPI.Controllers
//{
//    [Route("api/admin")]
//    [ApiController]
//    public class AdminController : ControllerBase
//    {

//        private readonly IAdminService _adminService;

//        public AdminController(IAdminService adminService)
//        {
//            _adminService = adminService;
//        }


//        [HttpGet("GetAllBreweries")]
//        [Produces("application/json")]
//        public IActionResult GetAllBreweries()
//        {
//            try
//            {
//                return Ok(_adminService.GetAllBreweries());
//            } catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpPost("AddBreweryManager")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult AddBreweryManager(Brewery brewery, User manager)
//        {
//            try
//            {
//                _adminService.AddBreweryManager(manager, brewery);
//                return CreatedAtAction("AddBreweryManager", brewery, manager);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
//        }

//        [HttpGet("getBrewerybyId/{breweryId}")]
//        [Produces("application/json")]
//        public IActionResult GetBrewerybyId(string breweryId)
//        {
//            try
//            {
//                return Ok(_adminService.GetBrewerybyId(breweryId));
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpGet("DeleteBreweryById/{breweryId}")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult DeleteBreweryById(string breweryId)
//        {
//            try
//            {
//                _adminService.DeleteBreweryById(breweryId);
//                return CreatedAtAction("DeleteBreweryById", breweryId);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
//        }

//        [HttpGet("DeleteManagerById/{managerId}")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult DeleteManagerById(string managerId)
//        {
//            try
//            {
//                _adminService.DeleteManagerById(managerId);
//                return CreatedAtAction("DeleteManagerById", managerId);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
//        }

//    }
//}
