using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Categories
{
    public class Category: BaseEntity
    {
        
        public string Name { get; set; }
        public string Desciription { get; set; }
        public List<Product> Products{ get; set; }
        public Category SubCategory{ get; set; }
        [ForeignKey(nameof(SubCategory))]
        public int? SubCategoryId { get; set; } 

    }
}
