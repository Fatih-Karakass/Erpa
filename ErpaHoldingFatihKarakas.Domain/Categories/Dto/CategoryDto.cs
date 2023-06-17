using ErpaHoldingFatihKarakas.Domain.Products.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Categories.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciription { get; set; }
        public List<ProductDto> Products { get; set; }

        public int? SubCategoryId { get; set; }
    }
}
