using ErpaHoldingFatihKarakas.Domain.Products;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;

namespace ErpaHoldingFatihKarakas.Repository.Products
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }

    }
}
