using ErpaHoldingFatihKarakas.Domain.Models;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Repository.Models
{
    public class ModelRepository : GenericRepository<Model, int>, IModelRepository
    {
        public ModelRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
