using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Products;

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
