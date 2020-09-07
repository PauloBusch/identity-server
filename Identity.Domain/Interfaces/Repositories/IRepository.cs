using Identity.Domain._Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<bool> ExistByIdAsync(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
