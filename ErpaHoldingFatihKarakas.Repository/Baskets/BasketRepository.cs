using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
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
    }
}
