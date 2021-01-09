using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Netflix.Infrastructure.Abstractions.DB
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
    }
}
