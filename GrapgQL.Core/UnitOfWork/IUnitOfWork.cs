using GrapgQL.Core.Entities;
using GrapgQL.Core.Repositories;

namespace GrapgQL.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        public void Commit();
        public Task CommitAsync();
        public IRepository<TEntity> GetRepostiory<TEntity>() where TEntity : Base, new();
    }
}
