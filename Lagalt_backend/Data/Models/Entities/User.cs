using System;
using System.Collections.Generic;

namespace Lagalt_backend.Data.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
            Skills = new HashSet<Skill>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string? Info { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
