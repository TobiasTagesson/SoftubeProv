using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SoftubeProv.Models
{
    public class Product
    {  
        public int totalResults { get; set; }
        public IEnumerable<Result> result { get; set; }
    }
}
