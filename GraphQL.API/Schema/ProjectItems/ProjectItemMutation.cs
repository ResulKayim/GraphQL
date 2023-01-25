using GrapgQL.Core.Entities;
using GrapgQL.Core.Services;

namespace GraphQL.API.Schema.ProjectItems
{
    [ExtendObjectType("Mutation")]
    public class ProjectItemMutation
    {
        public async Task<ProjectItem> CreateProjectItem(ProjectItem projectItem, [Service] IService<ProjectItem> service)
            => await service.Create(projectItem);

        public async Task<ProjectItem> UpdateProjectItem(ProjectItem projectItem, [Service] IService<ProjectItem> service)
            => await service.Update(projectItem);

        public async Task<Guid> DeleteProjectItem(Guid id, [Service] IService<ProjectItem> service)
        {
            await service.DeleteById(id);
            return id;
        }
    }
}
