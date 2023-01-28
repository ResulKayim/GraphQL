using GrapgQL.Core.Entities;

namespace GrapgQL.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : Base
    {
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> GetById(Guid id);
        public TEntity Update(TEntity entity);
        public Task<TEntity> Create(TEntity entity);
        public void DeleteById(Guid id);

    }
}
