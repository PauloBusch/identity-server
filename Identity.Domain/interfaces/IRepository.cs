using Identity.Domain.Utils.Common;

namespace Identity.Domain.interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<T> 
    }
}
