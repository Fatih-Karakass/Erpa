using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Orders;
using Microsoft.AspNetCore.Identity;

namespace ErpaHoldingFatihKarakas.Domain.Authentication
{
    public class User : IdentityUser<Guid>
    {
        public string TcNo { get; set; }
        public string? Photo { get; set; }
        public List<Order> Orders { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}
