using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Text;

namespace SoftubeProv.Models
{
    public class ProductRepository : IProductRepository
    {

        readonly string path = "https://cdn.softube.com/api/v1/products?pageSize=500";

        public async Task<Product> GetAllProducts()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64042");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Product>(result);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
