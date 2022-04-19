using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSoftube.Models;

namespace WebSoftube.ViewModels
{
    public class ProductViewModel
    {
        public int totalResults { get; set; }
        public List<Result> result { get; set; }
    }
}
