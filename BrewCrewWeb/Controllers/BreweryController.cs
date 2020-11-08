using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewCrewDB;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewCrewWeb.Controllers
{
    public class BreweryController : Controller
    {
        private readonly IAdminRepo _repo;
        // GET: /<controller>/
        public BreweryController(IAdminRepo repo)
        {
            this._repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
