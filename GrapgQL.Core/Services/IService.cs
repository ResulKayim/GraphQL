using GrapgQL.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapgQL.Core.Services
{
    public interface IService<TEntity> where TEntity : Base
    {
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> GetById(Guid id);
        public Task<TEntity> Update(TEntity entity);
        public Task<TEntity> Create(TEntity entity);
        public Task DeleteById(Guid id);
    }
}
