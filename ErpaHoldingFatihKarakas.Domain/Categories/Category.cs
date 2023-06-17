using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpaHoldingFatihKarakas.Domain.Categories
{
    public class Category : BaseEntity
    {

        public string Name { get; set; }
        public string Desciription { get; set; }
        public List<Product> Products { get; set; }
        public Category SubCategory { get; set; }
        [ForeignKey(nameof(SubCategory))]
        public int? SubCategoryId { get; set; }

    }
}
