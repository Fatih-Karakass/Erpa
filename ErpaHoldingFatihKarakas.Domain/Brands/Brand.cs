using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.Models;
using ErpaHoldingFatihKarakas.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Brands
{
    public class Brand: BaseEntity
    {
        
        public string Name { get; set; }
        public List<Product> Products{ get; set; }
       

    }
}
