using ErpaHoldingFatihKarakas.Domain.Models;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;

namespace ErpaHoldingFatihKarakas.Repository.Models
{
    public class ModelRepository : GenericRepository<Model, int>, IModelRepository
    {
        public ModelRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
