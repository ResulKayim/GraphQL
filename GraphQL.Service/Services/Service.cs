using GrapgQL.Core.Entities;
using GrapgQL.Core.Repositories;
using GrapgQL.Core.Services;
using GrapgQL.Core.UnitOfWork;

namespace GraphQL.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Base, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepostiory<TEntity>();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var entry = await _repository.Create(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task DeleteById(Guid id)
        {
            _repository.DeleteById(id);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var entry = await _repository.GetById(id);
            return entry;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var entry = _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            return entry;
        }
    }
}
