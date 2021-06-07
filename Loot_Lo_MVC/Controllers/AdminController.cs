using Loot_Lo_MVC.Helper;
using Loot_Lo_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;



namespace Loot_Lo_MVC.Controllers
{
    public class AdminController : Controller
    {
        API api = new API();
        public IActionResult AdminLoginForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(Admin admin)
        {
            List<Product> products = new List<Product>();
            HttpClient client = api.Initial();
            
            List<string> value = new List<string>();
            value.Add(admin.AdminEmail);
            value.Add(admin.AdminPassword);
            string contents = JsonConvert.SerializeObject(value);
            HttpResponseMessage result = await client.PostAsync("api/Admin/validateAdmin", new StringContent(contents, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                var results = result.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(results);
                //HttpResponseMessage getAdmin = await client.GetAsync("api/Admin/GetAdmin/" + admin.AdminEmail);
                //if (getAdmin.IsSuccessStatusCode)
                //{
                //    var result1 = getAdmin.Content.ReadAsStringAsync().Result;
                //    Admin admin1 = JsonConvert.DeserializeObject<Admin>(result1);
                //    HttpContext.Session.SetString("AdminId", admin1.AdminId.ToString());
                //}
                HttpContext.Session.SetString("AdminEmail", admin.AdminEmail);
            }
            //return View(products);
            return RedirectToAction("Index", "Product");

        }

        public IActionResult AdminRegistrationForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistereAdmin(Admin admin)
        {
            HttpClient client = api.Initial();
          
            JsonContent content = JsonContent.Create(admin);

            HttpResponseMessage response = await client.PostAsync("api/Admin", content);
            //return View("AdminLoginForm");
            return RedirectToAction("AdminLoginForm");
        }

       
        public IActionResult Logout()
        { 
            HttpContext.Session.Remove("AdminEmail");
            return RedirectToAction("Index", "Product");
        }

    }
}
