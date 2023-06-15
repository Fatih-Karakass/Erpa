using ErpaHoldingFatihKarakas.Domain.Baskets.Dto;
using ErpaHoldingFatihKarakas.Domain.Orders.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Services
{
    public interface IBasketServices
    {
        public Task AddProductToBasket(int productId,int productCount,Guid UserId);

        public Task<BasketDto> ListBasket(int basketId);
        public Task<BasketDto> BasketFinished(int basketId,string adress);
        public Task<OrderDto> OrderCreated(string description,BasketDto basket);
    }
}
