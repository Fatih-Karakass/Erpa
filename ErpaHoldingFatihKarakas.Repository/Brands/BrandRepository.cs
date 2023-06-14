using ErpaHoldingFatihKarakas.Domain.Brands;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Repository.Brands
{
    public class BrandRepository : GenericRepository<Brand, int>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
