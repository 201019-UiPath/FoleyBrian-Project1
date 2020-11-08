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
//    public class CustomerController : Controller
//    {
//        private readonly ICustomerService _customerService;

//        public CustomerController(ICustomerService customerService)
//        {
//            _customerService = customerService;
//        }

        

//        [HttpGet("AddCustomer")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult AddCustomer(User customer)
//        {
//            try
//            {
//                _customerService.AddCustomer(customer);
//                return CreatedAtAction("AddCustomer", customer);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
//        }

//        [HttpGet("PlaceOrder")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult PlaceOrder(Order order)
//        {
//            try
//            {
//                _customerService.PlaceOrder(order);
//                return CreatedAtAction("PlaceOrder", order);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
//        }

//        [HttpGet("GetUserByEmail/{email}")]
//        [Produces("application/json")]
//        public IActionResult GetUserByEmail(string email)
//        {
//            try
//            {
//                return Ok(_customerService.GetUserByEmail(email));
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpGet("GetAllBrewerys")]
//        [Produces("application/json")]
//        public IActionResult GetAllBreweries()
//        {
//            try
//            {
//                return Ok(_customerService.GetAllBreweries());
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpGet("GetAllBeersByBreweryId/{breweryId}")]
//        [Produces("application/json")]
//        public IActionResult GetAllBeersByBreweryId(string breweryId)
//        {
//            try
//            {
//                return Ok(_customerService.GetAllBeersByBreweryId(breweryId));
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        //[HttpGet("GetAllOrdersByCustomerBreweryId/{customerId}/{breweryId}")]
//        //[Produces("application/json")]
//        //public IActionResult GetAllOrdersByCustomerBreweryId(string customerId, string breweryId)
//        //{
//        //    try
//        //    {
//        //        return Ok(_customerService.GetAllOrdersByCustomerBreweryId(customerId, breweryId));
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        return StatusCode(500);
//        //    }
//        //}

//        [HttpGet("GetBeerById/{breerId}")]
//        [Produces("application/json")]
//        public IActionResult GetBeerById(string beerId)
//        {
//            try
//            {
//                return Ok(_customerService.GetBeerById(beerId));
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500);
//            }
//        }

//        //[HttpGet("UpdateBeer")]
//        //[Consumes("application/json")]
//        //[Produces("application/json")]
//        //public IActionResult UpdateBeer(Beer beer)
//        //{
//        //    try
//        //    {
//        //        _customerService.UpdateBeer(beer);
//        //        return CreatedAtAction("UpdateBeer", beer);
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        return BadRequest();
//        //    }
//        //}

//        [HttpGet("DeleteCustomerById/{customerId}")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public IActionResult DeleteCustomerById(string customerId)
//        {
//            try
//            {
//                _customerService.DeleteCustomerById(customerId);
//                return CreatedAtAction("DeleteCustomerById", customerId);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
//        }

//    }
//}
