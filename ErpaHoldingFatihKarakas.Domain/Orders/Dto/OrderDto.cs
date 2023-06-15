using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Baskets.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Orders.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }


        public BasketDto Basket{ get; set; }
        public int BasketId { get; set; }
    }
}
