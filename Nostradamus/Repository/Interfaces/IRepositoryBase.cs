using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nostradamus.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindById(string id);
        Task<T> FindById(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        //Task Save();
    }
}
