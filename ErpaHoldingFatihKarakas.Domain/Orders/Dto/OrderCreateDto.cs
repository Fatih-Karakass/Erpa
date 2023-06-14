using ErpaHoldingFatihKarakas.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Orders.Dto
{
    public class OrderCreateDto
    {
        public DateTime CreateTime { get; set; }
        
        public int BasketId { get; set; }
    }
}
