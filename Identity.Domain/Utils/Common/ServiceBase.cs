using Identity.Domain.Utils.interfaces;
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

        public async Task<Response<IEnumerable<TEntity>>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return new Response<IEnumerable<TEntity>>(list, list.Count());
        }

        public async Task<Response<TEntity>> GetAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            return new Response<TEntity>(entity);
        }

        public async Task<Response<IQueryable<TEntity>>> QueryAsync()
        {
            var query = await _repository.QueryAsync();
            return new Response<IQueryable<TEntity>>(query);
        }

        public async Task<Response> Update(TEntity entity)
        {
            await _repository.Update(entity);
            return await _uow.CommitAsync();
        }
    }
}
