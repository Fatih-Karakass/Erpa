using Microsoft.AspNetCore.Http;

namespace ErpaHoldingFatihKarakas.Domain.Products.Dto
{
    public class ProductCreateDto
    {

        public string Name { get; set; }
        public int Stock { get; set; }
        public int Desi { get; set; }
        public string Desciription { get; set; }
        public IFormFile Photo { get; set; }
        public bool IsPublished { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }       
        public int CategoryId { get; set; }
      
    }
}
