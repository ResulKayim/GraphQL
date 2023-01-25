using GrapgQL.Core.Entities;
using GrapgQL.Core.Services;

namespace GraphQL.API.Schema.Developers
{
    [ExtendObjectType("Mutation")]
    public class DeveloperMutation
    {
        public async Task<Developer> CreateDeveloper(Developer developer, [Service] IService<Developer> service)
            => await service.Create(developer);

        public async Task<Developer> UpdateDeveloper(Developer developer, [Service] IService<Developer> service)
            => await service.Update(developer);

        public async Task<Guid> DeleteDeveloper(Guid id, [Service] IService<Developer> service)
        {
            await service.DeleteById(id);
            return id;
        }
    }
}
