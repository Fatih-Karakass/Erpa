﻿using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Repository
{
    //User işlemleri burdan mı yapacak ?
    public class GenericRepository<T,Id> : IGenericRepository<T,Id> where T : class
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T Entity)
        {
            if(Entity == null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }
          var result= await _dbSet.AddAsync(Entity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task DeleteAsync(T Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }
            var result =  _dbSet.Remove(Entity);
            await _appDbContext.SaveChangesAsync();
            
        }

        public  IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable<T>();
        }

        public async Task<T> GetByIdAsync(Id Id)// servis katmanında , Controllerda null kontrol et
        {
            if(Id == null)
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
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
