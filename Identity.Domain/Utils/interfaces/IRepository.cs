using Identity.Domain.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Domain.Utils.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> Query();
        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
