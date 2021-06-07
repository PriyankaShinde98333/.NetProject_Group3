using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loot_Lo_MVC.Helper;
using Loot_Lo_MVC.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace Loot_Lo_MVC.Controllers
{
    public class ProductController : Controller
    {
        API api = new API();
        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Product");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(results);
            }
            return View(products);
        }

        public async Task<IActionResult> AddProduct()
        {
            List<Category> categoryList = new List<Category>();

            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Category");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                categoryList = JsonConvert.DeserializeObject<List<Category>>(results);
            }

            categoryList.Insert(0, new Category { CategoryId = 0, CategoryName = "Select" });
            ViewBag.ListOfCategory = categoryList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductAdded(Product product)
        {
            HttpClient client = api.Initial();
            //Category category = null;
            //HttpResponseMessage res = await client.GetAsync("api/Category/"+product.CategoryRefId);
            //if (res.IsSuccessStatusCode)
            //{
            //    var results = res.Content.ReadAsStringAsync().Result;
            //     category = JsonConvert.DeserializeObject<Category>(results);
            //    product.CategoryName = category.CategoryName;
            //}


            //product.AdminRefId =Convert.ToInt32(HttpContext.Session.GetString("AdminId"));
            JsonContent content = JsonContent.Create(product);

            HttpResponseMessage response = await client.PostAsync("api/Product", content);
            //return View("AdminLoginForm");
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> EditProduct(int id)
        {
            Product product = null;
            List<Category> categoryList = new List<Category>();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Category");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                categoryList = JsonConvert.DeserializeObject<List<Category>>(results);
            }

            ViewBag.ListOfCategory = categoryList;
            HttpResponseMessage prod = await client.GetAsync("api/Product/"+id);
            if (res.IsSuccessStatusCode)
            {
                var results = prod.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(results);
            }
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> ProductEdited(Product product)
        {
            HttpClient client = api.Initial();
            //product.AdminRefId =Convert.ToInt32(HttpContext.Session.GetString("AdminId"));
            JsonContent content = JsonContent.Create(product);

            HttpResponseMessage response = await client.PutAsync("api/Product/"+product.ProductId, content);
            //return View("AdminLoginForm");
            return RedirectToAction("Index");
        }


      
        public async Task<IActionResult> DeleteProduct(int id)
        { 
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.DeleteAsync("api/Product/" + id);
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
               
            }
            return RedirectToAction("Index"); 
        }



    }
}
