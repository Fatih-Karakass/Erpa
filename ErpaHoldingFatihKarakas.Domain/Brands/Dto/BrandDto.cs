using ErpaHoldingFatihKarakas.Domain.Products.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Brands.Dto
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
