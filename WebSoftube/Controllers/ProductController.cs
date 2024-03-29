﻿using Microsoft.AspNetCore.Mvc;
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

        readonly string path = "https://localhost:44396/api/product/";

        public async Task<IActionResult> Index(int? pageNumber)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:36167");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(path + "getallproducts");

                var vm = new ProductViewModel();

                if (response.IsSuccessStatusCode)
                {
                    int pageSize = 10;
                    string apiRes = await response.Content.ReadAsStringAsync();
                    vm = JsonSerializer.Deserialize<ProductViewModel>(apiRes);
                    return View(PaginatedList<Result>.CreatePagination(vm.result, pageNumber ?? 1, pageSize));
                }
                else
                {
                    return View();
                }
            }
        }

        public async Task<IActionResult> SearchForProduct(string name)
        {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:36167");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var itemJson = JsonSerializer.Serialize(name);
                    HttpResponseMessage response = await client.GetAsync(path + "searchforproductbyname?name=" + name);

                    if (response.IsSuccessStatusCode)
                    {
                        string apiRes = await response.Content.ReadAsStringAsync();
                        var results = JsonSerializer.Deserialize<ProductViewModel>(apiRes);

                        if (results.result.Count() > 1)
                        {
                            return View(results);
                        }
                        else
                        {
                            return View("~/Views/Product/ShowProduct.cshtml",results.result.FirstOrDefault());
                        }
                    }
                    else
                    {
                        return View("~/Views/Product/ShowProduct.cshtml");
                    }
                }
        }

        public async Task<IActionResult> ShowProduct(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:36167");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var itemJson = JsonSerializer.Serialize(name);
                HttpResponseMessage response = await client.GetAsync(path + "getproductbyname?name=" + name);

                if (response.IsSuccessStatusCode)
                {
                    string apiRes = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<Result>(apiRes);

                    return View(result);
                }
                else
                {
                    return View();
                }
            }
        }

    }
}
