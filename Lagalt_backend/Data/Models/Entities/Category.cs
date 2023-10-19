using System;
using System.Collections.Generic;

namespace Lagalt_backend.Data.Models.Entities {

    /// <summary>
    /// Defines an entity for a Category with Id, Name, Projects
    /// </summary>
    public partial class Category {
        public Category() {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
    }
}
