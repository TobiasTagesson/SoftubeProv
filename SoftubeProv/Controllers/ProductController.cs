using Microsoft.AspNetCore.Mvc;
using SoftubeProv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftubeProv.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _repository.GetAllProducts();

            if (products != null)
            {
                return Ok(products);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult GetProductByName(string name)
        {
            Result product = new Result(); ;
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            else
            {

                product = _repository.GetAllProducts().Result.result.FirstOrDefault(x => x.name.ToLower().Trim() == name.ToLower().Trim());

                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}