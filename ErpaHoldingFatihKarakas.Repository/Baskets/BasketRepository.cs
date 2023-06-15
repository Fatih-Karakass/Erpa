using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Repository.Baskets
{
    public class BasketRepository : GenericRepository<Basket, int>, IBasketRepository
    {
        
        public BasketRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
        public async Task UpdateProductCountBasket(int basketId,int productId,int productCount)
        {
            var basketproducts = await _appDbContext.BasketProducts.Where(x => x.BasketId == basketId && x.ProductId == productId).FirstOrDefaultAsync();
            if (basketproducts == null)
            {
                throw new Exception("Bulunamadı");
            }
            basketproducts.ProductCount = productCount;
            await _appDbContext.SaveChangesAsync();

        }
        public async Task RemoveProductFromBasket(int basketId,int productId)
        {
            var basketproducts = await _appDbContext.BasketProducts.Where(x => x.BasketId == basketId && x.ProductId == productId).FirstOrDefaultAsync();
            if (basketproducts == null)
            {
                throw new Exception("Bulunamadı");
            }
            _appDbContext.BasketProducts.Remove(basketproducts);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
