using POC.Cognito.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Cognito.Core.Interfaces
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        IUnitOfWork UnitOfWork { get; }
        Task<List<T>> FindAllAsync(bool asNoTracking = false);
        Task<T> FindByIdAsync(Guid id, bool asNoTracking = false);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
