using System;
using Serilog;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BrewCrewDB.Models;
using BrewCrewLib;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewCrewAPI.Controllers
{
    [Route("api/lineitem")]
    [ApiController]
    public class LineItemController : Controller
    {

        private readonly IService<LineItem> _service;

        public LineItemController(IService<LineItem> service)
        {
            this._service = service;
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAllLineItems()
        {
            try
            {
                List<LineItem> lineitems = _service.GetAllResources();
                Log.Information($"Successfully retrieved all line items");
                return Ok(lineitems);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve all line items - {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("Get/{id}")]
        [Produces("application/json")]
        public IActionResult GetLineItem(string id)
        {
            try
            {
                LineItem lineitem = _service.GetResource(id);
                Log.Information($"Successfully retrieved line item {id}");
                return Ok(lineitem);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to retrieve line item - {id} {e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddLineLitem(LineItem lineitem)
        {
            try
            {
                _service.AddResource(lineitem);
                Log.Information($"Successfully added line item {lineitem.ID}");
                return CreatedAtAction("AddLineItem", lineitem);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to add line item - {lineitem.ID} {e.Message}");
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateLineItem(LineItem lineitem)
        {
            try
            {
                _service.UpdateResource(lineitem);
                Log.Information($"Successfully updated line item {lineitem.ID}");
                return CreatedAtAction("UpdateLineItem", lineitem);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to update line item - {lineitem.ID} {e.Message}");
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteLineItem(LineItem lineitem)
        {
            try
            {
                _service.DeleteResource(lineitem);
                Log.Information($"Successfully deleted line item {lineitem.ID}");
                return CreatedAtAction("DeleteLineItem", lineitem);
            }
            catch (Exception e)
            {
                Log.Warning($"Unable to delete line item - {e.Message}");
                return BadRequest();
            }
        }
    }

}
