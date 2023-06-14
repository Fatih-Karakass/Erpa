using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.Orders;
using ErpaHoldingFatihKarakas.Domain.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Baskets
{
    public class Basket:BaseEntity
    {
        
        public User User{ get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId{ get; set; }
        public Order Order{ get; set; }
       
        public List<Product> Product { get; set; } = null!;
        public int ProductCount { get; set; }

        public bool IsOrdered { get; set; } = false;
    }
}
