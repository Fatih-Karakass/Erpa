using ErpaHoldingFatihKarakas.Domain.Products.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Baskets.Dto
{
    public class BasketCreateDto
    {


        public List<ProductDto> Products { get; set; }


        public bool IsOrdered { get; set; } = false;
    }
}
