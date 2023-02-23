using GrapgQL.Core.Entities;
using GrapgQL.Core.Repositories;
using GrapgQL.Core.UnitOfWork;
using GraphQL.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly AppDbContext _dbContext;
        private Dictionary<Type, object> repositories;

        public UnitOfWork(IDbContextFactory<AppDbContext> pooledDbContextFactory)
        {
            _dbContext = pooledDbContextFactory.CreateDbContext();
            repositories = new();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public IRepository<TEntity> GetRepostiory<TEntity>() where TEntity : Base, new()
        {
            if (repositories.ContainsKey(typeof(IRepository<TEntity>)))
                return (IRepository<TEntity>)repositories[typeof(IRepository<TEntity>)];

            IRepository<TEntity> repository = new Repository<TEntity>(_dbContext);
            repositories.Add(typeof(IRepository<TEntity>), repository);
            return repository;
            //return new Repository<TEntity>(_dbContext);
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
            repositories.Clear();
        }

    }
}
