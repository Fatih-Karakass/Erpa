using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Repositories
{
    public interface IGenericRepository<T,Id> where T: class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Id Id);
        Task<T> CreateAsync(T Entity);
        Task<T> UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
    }
}
