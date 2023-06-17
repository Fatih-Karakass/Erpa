using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.Products;

namespace ErpaHoldingFatihKarakas.Domain.Models
{
    public class Model : BaseEntity
    {

        public string Name { get; set; }
        public Product Product { get; set; }


    }
}
