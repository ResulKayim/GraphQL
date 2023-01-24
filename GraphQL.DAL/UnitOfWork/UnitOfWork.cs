using GrapgQL.Core.Entities;
using GrapgQL.Core.Repositories;
using GrapgQL.Core.UnitOfWork;
using GraphQL.DAL.Repositories;

namespace GraphQL.DAL.UnitOfWork
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : Base, new()
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
