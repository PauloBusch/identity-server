using Identity.Domain.Utils.Common;
using Identity.Domain.Utils.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Domain.Utils.interfaces
{
    public interface IService<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> Query();
        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<Response> Create(TEntity entity);
        Task<Response> Update(TEntity entity);
        Task<Response> Delete(TEntity entity);
    }
}
