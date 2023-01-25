using GrapgQL.Core.Entities;
using GrapgQL.Core.Services;

namespace GraphQL.API.Schema.ProjectItems
{
    [ExtendObjectType("Query")]
    public class ProjectItemQuery
    {
        [UseProjection, UseFiltering, UseSorting]
        public IQueryable<ProjectItem> GetProjectItems([Service] IService<ProjectItem> service)
                => service.GetAll();

        [UseProjection, UseFiltering, UseSorting]
        public async Task<ProjectItem> GetProjectItem(Guid id, [Service] IService<ProjectItem> service)
                => await service.GetById(id);
    }
}
