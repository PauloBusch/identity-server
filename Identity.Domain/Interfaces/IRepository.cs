using Identity.Domain.Utils.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
