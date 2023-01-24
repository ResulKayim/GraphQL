using GrapgQL.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.DAL.EntityConfigurations
{
    public class ProjectItemConfiguration : IEntityTypeConfiguration<ProjectItem>
    {
        public void Configure(EntityTypeBuilder<ProjectItem> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(1000);
        }
    }
}
