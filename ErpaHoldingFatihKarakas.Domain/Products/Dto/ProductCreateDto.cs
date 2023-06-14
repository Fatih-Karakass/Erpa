using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Brands;
using ErpaHoldingFatihKarakas.Domain.Categories;
using ErpaHoldingFatihKarakas.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Products.Dto
{
    public class ProductCreateDto
    {

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
