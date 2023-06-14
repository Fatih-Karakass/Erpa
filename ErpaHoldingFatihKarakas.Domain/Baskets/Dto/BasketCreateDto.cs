using ErpaHoldingFatihKarakas.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Baskets.Dto
{
    public class BasketCreateDto
    {


        public List<Product> Products { get; set; }
        public int ProductCount { get; set; }

        public bool IsOrdered { get; set; } = false;
    }
}
