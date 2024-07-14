﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.DataAccess
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>, IAsyncRepository<TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        private readonly TContext Context;
        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }
        public IQueryable<TEntity> Query() => Context.Set<TEntity>();

        public void Add(TEntity entity)
        {
            Context.Add(entity);
            entity.CreatedDate = DateTime.UtcNow;
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public void SoftDelete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.UtcNow;
            Context.Update(entity);
            Context.SaveChanges();
        }
        public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if (include != null)
                data = include(data);

            return data.FirstOrDefault(predicate);
        }
        public void Update(TEntity entity)
        {
            Context.Update(entity);
            entity.UpdatedDate = DateTime.UtcNow;
            Context.SaveChanges();
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.AddAsync(entity);
            entity.CreatedDate = DateTime.UtcNow;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.UtcNow;
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if (include != null)
                data = include(data);

            return await data.Where(predicate).ToListAsync();
        }
     
        public async Task UpdateAsync(TEntity entity)
        {
            Context.Update(entity);
            entity.UpdatedDate = DateTime.UtcNow;
            await Context.SaveChangesAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if (include != null)
                data = include(data);


            return await data.FirstOrDefaultAsync(predicate);
        }
    }
}
