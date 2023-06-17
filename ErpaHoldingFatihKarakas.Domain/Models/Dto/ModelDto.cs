using ErpaHoldingFatihKarakas.Domain.Products.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Models.Dto
{
    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductDto Product { get; set; }
    }
}
