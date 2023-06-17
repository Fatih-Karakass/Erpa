using ErpaHoldingFatihKarakas.Domain.Orders;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;

namespace ErpaHoldingFatihKarakas.Repository.Orders
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
