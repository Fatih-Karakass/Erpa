using ErpaHoldingFatihKarakas.Domain.Orders;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Repository.Orders
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
