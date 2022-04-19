using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Text;

namespace SoftubeProv.Models
{
    public class ProductRepository : IProductRepository
    {
       // private readonly IProductRepository _productRepository;

      //  static HttpClient client = new HttpClient();
        string path = "https://cdn.softube.com/api/v1/products?pageSize=500";

        //public ProductRepository(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        public async Task<Product> GetAllProducts()
       // public async Task<List<Result>> GetAllProducts()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64042");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var response = await client.GetStringAsync(path);

                return  JsonSerializer.Deserialize<Product>(response);

            }

            //using (var client = new HttpClient())
            //{
            //    Product product = new Product(); 
            //    client.BaseAddress = new Uri("http://localhost:64042");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage response = await client.GetAsync(path);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        product = await response.Content.ReadAsAsync<Product>();
            //    }
            //    return product;
            //}

        }

        public Product GetProductByName(string name)
        {
            

            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(name, Encoding.UTF8, "application/json");

                var requestBodyAsString = JsonSerializer.Serialize(name);

                var jsonString = string.Empty;

                using (var response = client.PostAsync(path, content).Result)
                {
                    jsonString = response.Content.ReadAsStringAsync().Result;
                }

            }

            throw new NotImplementedException();
        }
    }
}
