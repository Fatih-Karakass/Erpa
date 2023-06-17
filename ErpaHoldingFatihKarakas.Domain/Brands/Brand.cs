using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.Products;

namespace ErpaHoldingFatihKarakas.Domain.Brands
{
    public class Brand : BaseEntity
    {

        public string Name { get; set; }
        public List<Product> Products { get; set; }


    }
}
