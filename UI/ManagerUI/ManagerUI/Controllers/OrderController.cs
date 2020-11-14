using System;
using Microsoft.AspNetCore.Mvc;
using ManagerUI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerUI.Controllers
{
    public class OrderController : Controller
    {
        const string url = "https://localhost:47720/";

        public IActionResult Orders()
        {
            return View();
        }
    }
}
