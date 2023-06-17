using ErpaHoldingFatihKarakas.Domain.Baskets.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Orders.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }


        public BasketDto Basket { get; set; }
        public int BasketId { get; set; }
    }
}
