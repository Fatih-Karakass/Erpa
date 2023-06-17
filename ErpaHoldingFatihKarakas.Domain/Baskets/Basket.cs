using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.Orders;
using ErpaHoldingFatihKarakas.Domain.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpaHoldingFatihKarakas.Domain.Baskets
{
    public class Basket : BaseEntity
    {

        public User User { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public Order Order { get; set; }

        public List<Product> Products { get; set; }


        public bool IsOrdered { get; set; } = false;
    }
}
