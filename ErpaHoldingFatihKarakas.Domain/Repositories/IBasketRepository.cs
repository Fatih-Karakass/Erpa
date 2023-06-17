using ErpaHoldingFatihKarakas.Domain.Baskets;

namespace ErpaHoldingFatihKarakas.Domain.Repositories
{
    public interface IBasketRepository : IGenericRepository<Basket, int>
    {
        Task UpdateProductCountBasket(int basketId, int productId, int productCount);

    }
}
