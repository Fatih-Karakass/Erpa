using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.Baskets;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpaHoldingFatihKarakas.Domain.Orders
{
    public class Order : BaseEntity
    {



        public Basket Basket { get; set; }
        [ForeignKey(nameof(Basket))]
        public int BasketId { get; set; }
        public string Adress { get; set; }

    }
}
