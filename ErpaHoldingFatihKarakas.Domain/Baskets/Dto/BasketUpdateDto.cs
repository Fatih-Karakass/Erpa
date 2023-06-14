using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Orders;
using ErpaHoldingFatihKarakas.Domain.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Baskets.Dto
{
    public class BasketUpdateDto
    {
        public int Id { get; set; }
   
    
        public List<Product> Products { get; set; }
        public int ProductCount { get; set; }

        public bool IsOrdered { get; set; } = false;
    }
}
