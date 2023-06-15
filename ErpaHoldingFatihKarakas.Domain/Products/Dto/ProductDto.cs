using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Products.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Desi { get; set; }
        public string Desciription { get; set; }
        public string Photo { get; set; }
        public bool IsPublished { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

    }
}
