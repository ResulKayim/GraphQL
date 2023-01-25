﻿using GrapgQL.Core.Entities;
using GrapgQL.Core.Repositories;
using GrapgQL.Core.UnitOfWork;
using GraphQL.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAL.UnitOfWork
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>, IAsyncDisposable where TEntity : Base, new()
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(IDbContextFactory<AppDbContext> pooledDbContextFactory)
        {
            _dbContext = pooledDbContextFactory.CreateDbContext();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IRepository<TEntity> Repostiory()
        {
            return new Repository<TEntity>(_dbContext);
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
