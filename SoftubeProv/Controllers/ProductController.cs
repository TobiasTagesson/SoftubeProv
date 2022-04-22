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
        public IActionResult SearchForProductByName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            else
            {
                Product product = new Product();
                var texts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(t => t.ToLower());
                product.result = _repository.GetAllProducts().Result.result.Where(x => texts.All(t => x.name.ToLower().Contains(t)));

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

        [HttpGet]
        public IActionResult GetProductByName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }

            else
            {
                var product = _repository.GetAllProducts().Result.result.FirstOrDefault(x => x.name == name);

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