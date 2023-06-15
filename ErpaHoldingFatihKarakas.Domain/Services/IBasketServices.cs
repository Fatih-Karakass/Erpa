using ErpaHoldingFatihKarakas.Domain.Baskets.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Services
{
    public interface IBasketServices
    {
        public Task AddProductToBasket(int productId,int productCount,Guid UserId);
        public Task RemoveProductFromBasket(int productId);
        public Task<BasketUpdateDto> UpdateBasket(int productId, int basketId,int productCount);
        public Task<BasketDto> ListBasket(int basketId);
    }
}
