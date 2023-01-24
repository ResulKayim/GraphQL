using GrapgQL.Core.Entities;
using GrapgQL.Core.Repositories;

namespace GrapgQL.Core.UnitOfWork
{
    public interface IUnitOfWork<TEntity> where TEntity : Base
    {
        public void Commit();
        public Task CommitAsync();
        public IRepository<TEntity> Repostiory();
    }
}
