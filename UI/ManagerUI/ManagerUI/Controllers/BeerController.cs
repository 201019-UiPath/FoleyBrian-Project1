using System;
using Microsoft.AspNetCore.Mvc;
using ManagerUI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerUI.Controllers
{
    

    public class BeerController : Controller
    {

        const string url = "https://localhost:47720/";

        [HttpGet]
        public IActionResult Beers()
        {
            string managerid = HttpContext.Session.GetObject<string>("managerid");
            if (managerid == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (ModelState.IsValid)
            {
               
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    //get manager from brewery managers table
                    var breweryManagerResponse = client.GetAsync($"api/brewerymanager/get/{managerid}");
                    breweryManagerResponse.Wait();

                    var breweryManagerResult = breweryManagerResponse.Result;
                    if (breweryManagerResult.IsSuccessStatusCode)
                    {
                        var brewerymanagerjsonString = breweryManagerResult.Content.ReadAsStringAsync();
                        brewerymanagerjsonString.Wait();

                        var dbBreweryManager = JsonConvert.DeserializeObject<BreweryManager>(brewerymanagerjsonString.Result);

                        //get brewery from value recieved from brewery managers table
                        var breweryResponse = client.GetAsync($"api/brewery/get/{dbBreweryManager.BreweryID}");
                        breweryResponse.Wait();

                        var breweryResult = breweryResponse.Result;
                        if (breweryResult.IsSuccessStatusCode)
                        {
                            var breweryjsonString = breweryResult.Content.ReadAsStringAsync();
                            breweryjsonString.Wait();

                            var dbBrewery = JsonConvert.DeserializeObject<Brewery>(breweryjsonString.Result);
                            HttpContext.Session.SetObject("brewery", dbBrewery);
                            return View(dbBrewery.Beers);

                        }
                    }
                }
            }
            return View();
        }

        public ViewResult Edit(string id)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var beerResponse = client.GetAsync($"api/beer/get/{id}");
                    beerResponse.Wait();

                    var beerResult = beerResponse.Result;
                    if (beerResult.IsSuccessStatusCode)
                    {
                        var beerjsonString = beerResult.Content.ReadAsStringAsync();
                        beerjsonString.Wait();

                        var dbBeer = JsonConvert.DeserializeObject<Beer>(beerjsonString.Result);
                        return View(dbBeer);
                    }
                }
            }
            return View();
        }

        public IActionResult UpdateBeer(Beer beer)
        {
            Brewery brewery = HttpContext.Session.GetObject<Brewery>("brewery");
            beer.BreweryID = brewery.ID;
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    var beerjson = JsonConvert.SerializeObject(beer);
                    var beerdata = new StringContent(beerjson, Encoding.UTF8, "application/json");

                    var response = client.PutAsync("api/beer/update", beerdata);
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        Console.Write("SUCCESS!");
                    }
                }
            }
            return RedirectToAction("Beers", "Beer");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddBeer(Beer beer)
        {
            Brewery brewery = HttpContext.Session.GetObject<Brewery>("brewery");
            if (ModelState.IsValid)
            {
                beer.ID = Guid.NewGuid().ToString();
                beer.BreweryID = brewery.ID;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    var beerjson = JsonConvert.SerializeObject(beer);
                    var beerdata = new StringContent(beerjson, Encoding.UTF8, "application/json");

                    var response = client.PostAsync("api/beer/add", beerdata);
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        Console.Write("SUCCESS!");
                    }
                }
            }
            return RedirectToAction("Beers", "Beer");
        }

        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    //First get the beer from db
                    client.BaseAddress = new Uri(url);
                    var beerResponse = client.DeleteAsync($"api/beer/delete/{id}");
                    beerResponse.Wait();

                    var beerResult = beerResponse.Result;
                    if (beerResult.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Success!");
                    }
                }
            }
            return RedirectToAction("Beers", "Beer");
        }
    }
}
