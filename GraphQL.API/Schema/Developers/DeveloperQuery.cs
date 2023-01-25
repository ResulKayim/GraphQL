using GrapgQL.Core.Entities;
using GrapgQL.Core.Services;

namespace GraphQL.API.Schema.Developers
{
    [ExtendObjectType("Query")]
    public class DeveloperQuery
    {
        [UseProjection, UseFiltering, UseSorting]
        public IQueryable<Developer> GetDevelopers([Service] IService<Developer> service)
                => service.GetAll();

        [UseProjection, UseFiltering, UseSorting]
        public async Task<Developer> GetDeveloper(Guid id, [Service] IService<Developer> service)
                => await service.GetById(id);
    }
}
