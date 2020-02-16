using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nostradamus.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nostradamus.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected NostradamusContext _nostradamusContext { get; set; }

        public RepositoryBase(NostradamusContext nostradamusContext)
        {
            this._nostradamusContext = nostradamusContext;
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await this._nostradamusContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._nostradamusContext.Set<T>().Where(expression).AsNoTracking();
        }

        
        public async Task<T> FindById(string id)
        {
            return await this._nostradamusContext.Set<T>().FindAsync(id);
        }

        public async Task<T> FindById(int id)
        {
            return await this._nostradamusContext.Set<T>().FindAsync(id);
        }

        public async Task Create(T entity)
        {
            this._nostradamusContext.Set<T>().Add(entity);
            await _nostradamusContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            this._nostradamusContext.Set<T>().Update(entity);
            await _nostradamusContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            this._nostradamusContext.Set<T>().Remove(entity);
            await _nostradamusContext.SaveChangesAsync();
        }
    }
}
