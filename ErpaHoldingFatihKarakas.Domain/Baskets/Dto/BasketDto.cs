using ErpaHoldingFatihKarakas.Domain.Products.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Baskets.Dto
{
    public class BasketDto
    {
        public int Id { get; set; }
        public List<ProductDto> Products { get; set; }


        public bool IsOrdered { get; set; }
    }
}
