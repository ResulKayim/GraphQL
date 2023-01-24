using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapgQL.Core.Entities
{
    public class Developer : Base
    {
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<ProjectItem> ProjectItems { get; set; }
    }
}
