using System;
using Microsoft.AspNetCore.Mvc;
using ManagerUI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerUI.Controllers
{
    public class OrderController : Controller
    {
        const string url = "https://localhost:47720/";

        public IActionResult Orders()
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    Brewery brewery = HttpContext.Session.GetObject<Brewery>("brewery");
                    client.BaseAddress = new Uri(url);
                    var orderResponse = client.GetAsync($"api/order/get/brewery/{brewery.ID}");
                    orderResponse.Wait();

                    //get validate user credentials are correct
                    var orderResult = orderResponse.Result;
                    if (orderResult.IsSuccessStatusCode)
                    {
                        var orderjsonString = orderResult.Content.ReadAsStringAsync();
                        orderjsonString.Wait();

                        var dbOrder = JsonConvert.DeserializeObject<List<Order>>(orderjsonString.Result);
                        HttpContext.Session.SetObject("order", dbOrder);
                        return View(dbOrder);
                    }
                }

            }
            return View();
        }

        public IActionResult SortDateAsc()
        {
            List<Order> order = HttpContext.Session.GetObject<List<Order>>("order");
            order = order.OrderBy(x => x.Date).ToList();
            foreach (var item in order.OrderBy(o => o.Date));
            return View("Orders",order);
        }

        public IActionResult SortDateDesc()
        {
            List<Order> order = HttpContext.Session.GetObject<List<Order>>("order");
            order = order.OrderByDescending(x => x.Date).ToList();
            foreach (var item in order.OrderBy(o => o.Date)) ;
            return View("Orders",order);
        }

        public IActionResult SortTotalAsc()
        {
            List<Order> order = HttpContext.Session.GetObject<List<Order>>("order");
            order = order.OrderBy(x => x.TotalPrice).ToList();
            foreach (var item in order.OrderBy(o => o.TotalPrice));
            return View("Orders",order);
        }

        public IActionResult SortTotalDesc()
        {
            List<Order> order = HttpContext.Session.GetObject<List<Order>>("order");
            order = order.OrderByDescending(x => x.TotalPrice).ToList();
            foreach (var item in order.OrderBy(o => o.TotalPrice)) ;
            return View("Orders", order);
        }
    }

    
}
