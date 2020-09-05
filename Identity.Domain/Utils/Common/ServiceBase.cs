using Identity.Domain.Utils.Interfaces;
using Identity.Domain.Utils.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Domain.Utils.Common
{
    public class ServiceBase<TEntity> : IService<TEntity> 
        where TEntity : EntityBase
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IUnitOfWork _uow; 

        public ServiceBase(
            IUnitOfWork uow, 
            IRepository<TEntity> repository
        ) {
            _uow = uow;
            _repository = repository;
        }

        public async Task<Response> Create(TEntity entity)
        {
            await _repository.Create(entity);
            return await _uow.CommitAsync();
        }

        public async Task<Response> Delete(TEntity entity)
        {
            await _repository.Delete(entity);
            return await _uow.CommitAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public IQueryable<TEntity> Query()
        {
            return _repository.Query();
        }

        public async Task<Response> Update(TEntity entity)
        {
            await _repository.Update(entity);
            return await _uow.CommitAsync();
        }
    }
}
