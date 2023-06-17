using ErpaHoldingFatihKarakas.Domain.Categories;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;

namespace ErpaHoldingFatihKarakas.Repository.Categories
{
    public class CategoriesRepository : GenericRepository<Category, int>, ICategoryRepository
    {
        public CategoriesRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
