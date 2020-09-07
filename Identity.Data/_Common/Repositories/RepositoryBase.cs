using Identity.Data.Context;
using Identity.Domain._Common.Entities;
using Identity.Domain._Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Data._Common.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        protected readonly IdentityContext _context;
        private readonly DbSet<TEntity> _dataset;

        public RepositoryBase(IdentityContext context)
        {
            _context = context;
            _dataset = context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            entity.Id = entity.Id == Guid.Empty 
                ? Guid.NewGuid() 
                : entity.Id;
            entity.CreatedAt = DateTime.UtcNow;
            await _dataset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityDb = await _dataset.FindAsync(id);
            _dataset.Remove(entityDb);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(e => e.Id.Equals(id));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dataset.ToArrayAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _dataset.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var entityDb = await _dataset.FindAsync(entity.Id);
            entity.CreatedAt = entityDb.CreatedAt;
            entity.UpdatedAt = DateTime.UtcNow;
            _context.Entry(entityDb).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
