using System;
using System.Collections.Generic;

namespace Lagalt_backend.Data.Models.Entities
{
    public partial class Category
    {
        public Category()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
    }
}
