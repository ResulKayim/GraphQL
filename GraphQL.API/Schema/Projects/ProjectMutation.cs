using GrapgQL.Core.Entities;
using GrapgQL.Core.Services;

namespace GraphQL.API.Schema.Projects
{
    [ExtendObjectType("Mutation")]
    public class ProjectMutation
    {
        public async Task<Project> CreateProject(Project project, [Service] IService<Project> service)
            => await service.Create(project);

        public async Task<Project> UpdateProject(Project project, [Service] IService<Project> service)
            => await service.Update(project);
        
        public async Task<Guid> DeleteProject(Guid id, [Service] IService<Project> service)
        {
            await service.DeleteById(id);
            return id;
        }
    }
}
