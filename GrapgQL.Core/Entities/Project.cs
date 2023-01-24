using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapgQL.Core.Entities
{
    public class Project : Base
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }

        public ICollection<Developer> Developers { get; set; }
        public ICollection<ProjectItem> ProjectItems { get; set; }

    }
}
