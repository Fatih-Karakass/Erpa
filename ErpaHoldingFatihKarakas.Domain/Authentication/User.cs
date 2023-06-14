using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Orders;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Authentication
{
    public class User:IdentityUser<Guid>
    {
        public int TcNo { get; set; }
        public string Photo { get; set; }
        public List<Order> Orders{ get; set; }
        public List<Basket> Baskets{ get; set; }
    }
}
