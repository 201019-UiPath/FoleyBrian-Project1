using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                return Ok(_service.GetAllResources());
            }
            catch (Exception e)
            {
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
                return CreatedAtAction("AddLineItem", lineitem);
            }
            catch (Exception)
            {
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
                return CreatedAtAction("UpdateLineItem", lineitem);
            }
            catch (Exception)
            {
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
                return CreatedAtAction("DeleteLineItem", lineitem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }

}
