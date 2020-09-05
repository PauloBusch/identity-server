using Identity.Domain.Utils.Common;
using Identity.Domain.Utils.Interfaces;
using Identity.Infrastructure.Utils.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Utils.Common
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly IdentityContext _context;
        private readonly DbSet<TEntity> _repository;

        public RepositoryBase(IdentityContext context)
        {
            _context = context;
            _repository = context.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task Delete(TEntity entity)
        {
            _repository.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.ToArrayAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _repository.FindAsync(id);
        }

        public IQueryable<TEntity> Query()
        {
            return _repository.AsQueryable();
        }

        public async Task Update(TEntity entity)
        {
            _repository.Update(entity);
            await Task.CompletedTask;
        }
    }
}
