using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Brands;
using ErpaHoldingFatihKarakas.Domain.Categories;
using ErpaHoldingFatihKarakas.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpaHoldingFatihKarakas.Domain.Products
{
    public class Product: BaseEntity
    {
        
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Desi { get; set; }
        public string Desciription { get; set; }
        public string Photo { get; set; }
        public bool IsPublished{ get; set; }//ürün yayında mı ?
        public Model Model{ get; set; }
        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }
        public Brand Brand{ get; set; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public Category Category{ get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public List<Basket> Basket{ get; set; }
       

    }
}
