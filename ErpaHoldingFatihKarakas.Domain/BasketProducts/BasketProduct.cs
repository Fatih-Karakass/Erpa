using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.BasketProducts
{
    public class BasketProduct
    {
        
        public Basket Basket { get; set; }

        public int BasketId { get; set; }
       

        public Product Product { get; set; }

        public int ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
