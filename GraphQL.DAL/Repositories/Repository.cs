using GrapgQL.Core.Entities;
using GrapgQL.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Base, new()
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        public void DeleteById(Guid id)
        {
            var entry = new TEntity { Id = id };
            _dbContext.Entry(entry);
            _dbSet.Remove(entry);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }
    }
}
