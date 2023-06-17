using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ErpaHoldingFatihKarakas.Repository
{
    //User işlemleri burdan mı yapacak ?
    public class GenericRepository<T, Id> : IGenericRepository<T, Id> where T : class
    {
        protected readonly ApplicationDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }
            var result = await _dbSet.AddAsync(Entity);

            return result.Entity;

        }

        public async Task DeleteAsync(T Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }
            var result = _dbSet.Remove(Entity);


        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable<T>();
        }

        public async Task<T> GetByIdAsync(Id Id)// servis katmanında , Controllerda null kontrol et
        {
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            return await _dbSet.FindAsync(Id);


        }

        public async Task<T> UpdateAsync(T Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }
            var result = _dbSet.Update(Entity);

            return result.Entity;
        }
    }
}
