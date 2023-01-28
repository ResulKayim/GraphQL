using GrapgQL.Core.Services;
using GrapgQL.Core.UnitOfWork;
using GraphQL.API.Schema.Developers;
using GraphQL.API.Schema.ProjectItems;
using GraphQL.API.Schema.Projects;
using GraphQL.DAL;
using GraphQL.DAL.UnitOfWork;
using GraphQL.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.
    AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectManagement")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// GraphQL
builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
    .AddQueryType(x => x.Name("Query")).AddType<DeveloperQuery>().AddType<ProjectQuery>().AddType<ProjectItemQuery>()
    .AddMutationType(x => x.Name("Mutation")).AddType<DeveloperMutation>().AddType<ProjectMutation>().AddType<ProjectItemMutation>()
    .AddProjections().AddFiltering().AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();
