using System;
using System.Collections.Generic;

namespace Lagalt_backend.Data.Models.Entities
{
    public partial class User
    {
        public User()
        {
            CollaboratorApplications = new HashSet<CollaboratorApplication>();
            ProjectsCreator = new HashSet<Project>();
            ProjectsCollaborator = new HashSet<Project>();
            Skills = new HashSet<Skill>();
        }

        public string Username { get; set; } = null!;
        public string? Info { get; set; }
        public string? ImageUrl { get; set; }
        public bool Hidden { get; set; }

        public virtual ICollection<CollaboratorApplication> CollaboratorApplications { get; set; }
        public virtual ICollection<Project> ProjectsCreator { get; set; }

        public virtual ICollection<Project> ProjectsCollaborator { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
