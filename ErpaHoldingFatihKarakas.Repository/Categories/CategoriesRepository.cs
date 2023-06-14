using ErpaHoldingFatihKarakas.Domain.Categories;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Repository.Categories
{
    public class CategoriesRepository : GenericRepository<Category, int>, ICategoryRepository
    {
        public CategoriesRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
