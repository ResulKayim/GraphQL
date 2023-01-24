using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapgQL.Core.Entities
{
    public class ProjectItem : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public Guid ProjectId { get; set; }

        public ICollection<Developer> Developers { get; set; }
        public Project Project { get; set; }

    }
}
