using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftubeProv.Models
{
    public interface IProductRepository
    {
        //  Task<List<Product>> GetAllProducts();
        Task<Product> GetAllProducts();
        Product GetProductByName(string name);
    }
}
