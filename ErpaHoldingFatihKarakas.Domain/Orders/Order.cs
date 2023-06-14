using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Orders
{
    public class Order: BaseEntity
    {
        
        public DateTime CreateTime { get; set; }

        public Basket Basket{ get; set; }
        [ForeignKey(nameof(Basket))]
        public int BasketId { get; set; }

    }
}
