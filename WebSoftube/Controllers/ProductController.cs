using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WebSoftube.Models;
using WebSoftube.ViewModels;

namespace WebSoftube.Controllers
{
    public class ProductController : Controller
    {

        string path = "https://localhost:44396/api/product/";

        public async Task<IActionResult> Index()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:36167");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetStringAsync(path + "getallproducts");

                var vm =  JsonSerializer.Deserialize<ProductViewModel>(response);
                return View(vm);
            }

        }

        public async Task<IActionResult> GetByName(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:36167");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var itemJson = JsonSerializer.Serialize(name);
                var response = await client.GetStringAsync(path + "getproductbyname?name=" + name);

                var vm = JsonSerializer.Deserialize<Result>(response);

                return View(vm);
            }

        }
    }
}
