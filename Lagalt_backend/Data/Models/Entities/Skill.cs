using System;
using System.Collections.Generic;

namespace Lagalt_backend.Data.Models.Entities {

    /// <summary>
    /// Defines an entity for a Skill
    /// </summary>
    public partial class Skill {
        public Skill() {
            Projects = new HashSet<Project>();
            Usernames = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<User> Usernames { get; set; }
    }
}
