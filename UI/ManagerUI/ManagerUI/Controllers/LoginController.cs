using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManagerUI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerUI.Controllers
{

    

    public class LoginController : Controller
    {
        const string url = "https://localhost:47720/";

        // GET: /<controller>/
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if(ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var userResponse = client.GetAsync($"api/user/get/Login/{user.Email}");
                    userResponse.Wait();

                    //get validate user credentials are correct
                    var userResult = userResponse.Result;
                    if (userResult.IsSuccessStatusCode)
                    {
                        var userjsonString = userResult.Content.ReadAsStringAsync();
                        userjsonString.Wait();

                        var dbUser = JsonConvert.DeserializeObject<User>(userjsonString.Result);

                        if (user.Email == dbUser.Email && user.Password == dbUser.Password && dbUser.Type.Equals("manager") )
                        {
                            HttpContext.Session.SetObject("managerid", dbUser.ID);
                            return RedirectToAction("Beers", "Beer");
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "Invalid Password");
                            return View(user);
                        }
                    }
                }
                
            }
            ModelState.AddModelError("Error", "Invalid Email or Password");
            return View(user);
            
            
        }
    }
}
