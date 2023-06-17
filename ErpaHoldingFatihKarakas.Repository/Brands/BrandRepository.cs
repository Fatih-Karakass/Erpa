using ErpaHoldingFatihKarakas.Domain.Brands;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;

namespace ErpaHoldingFatihKarakas.Repository.Brands
{
    public class BrandRepository : GenericRepository<Brand, int>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
