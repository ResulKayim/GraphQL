using GrapgQL.Core.Entities;
using GrapgQL.Core.Services;

namespace GraphQL.API.Schema.Projects
{
    [ExtendObjectType("Query")]
    public class ProjectQuery
    {
        [UseProjection, UseFiltering, UseSorting]
        public IQueryable<Project> GetProjects([Service] IService<Project> service)
                => service.GetAll();

        [UseProjection, UseFiltering, UseSorting]
        public async Task<Project> GetProject(Guid id, [Service] IService<Project> service)
                => await service.GetById(id);
    }
}
