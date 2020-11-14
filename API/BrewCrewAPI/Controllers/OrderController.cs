using System;
using Microsoft.AspNetCore.Mvc;
using BrewCrewLib;
using BrewCrewDB.Models;
using Serilog;
using System.Collections.Generic;

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
                List<Order> orders = _service.GetAllResources();
                Log.Information($"Successfully retrieved all orders");
                return Ok(orders);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve order - {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("Get/user/{id}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByUserId(string id)
        {
            try
            {
                List<Order> orders = _service.GetAllOrdersByCustomerId(id);
                Log.Information($"Successfully retrieved all orders from customer {id}");
                return Ok(orders);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve order - {id} {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("Get/brewery/{id}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByBreweryId(string id)
        {
            try
            {
                List<Order> orders = _service.GetAllOrdersByBreweryId(id);
                Log.Information($"Successfully retrieved all orders from brewery {id}");
                return Ok(orders);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve order from brewery - {e} {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("Get/{id}")]
        [Produces("application/json")]
        public IActionResult GetOrder(string id)
        {
            try
            {
                Order order = _service.GetResource(id);
                Log.Information($"Successfully retrieved order {id}");
                return Ok(order);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve order - {id} {e.Message}");
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
                Log.Information($"Successfully added order {order.ID}");
                return CreatedAtAction("AddOrder", order);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to add order - {order.ID} {e.Message}");
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
                Log.Information($"Successfully updated order {order.ID}");
                return CreatedAtAction("UpdateOrder", order);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to update order - {order.ID} {e.Message}");
                return BadRequest();
            }
        }

        [HttpDelete("Delete/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteOrder(string id)
        {
            try
            {
                _service.DeleteResource(id);
                Log.Information($"Successfully deleted order {id}");
                return CreatedAtAction("DeleteBrewery", id);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to delete order - {id} {e.Message}");
                return BadRequest();
            }
        }
    }
}
