using System;
using Microsoft.AspNetCore.Mvc;
using BrewCrewLib;
using BrewCrewDB.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewCrewAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IService<Order> _service;

        public OrderController(IService<Order> service)
        {
            this._service = service;
        }


        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAllOrders()
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
        public IActionResult GetOrder(string id)
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
        public IActionResult AddOrder(Order order)
        {
            try
            {
                _service.AddResource(order);
                return CreatedAtAction("AddOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateOrder(Order order)
        {
            try
            {
                _service.UpdateResource(order);
                return CreatedAtAction("UpdateOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteOrder(Order order)
        {
            try
            {
                _service.DeleteResource(order);
                return CreatedAtAction("DeleteBrewery", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
