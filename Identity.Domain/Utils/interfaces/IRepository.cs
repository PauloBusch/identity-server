using Identity.Domain.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Domain.Utils.interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> GetAsync(Guid id);
        Task<IQueryable<TEntity>> QueryAsync();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
