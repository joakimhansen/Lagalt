using System;
using System.Collections.Generic;

namespace Lagalt_backend.Data.Models.Entities {

    /// <summary>
    /// Defines an entity for a Project
    /// </summary>
    public partial class Project {
        public Project() {
            CollaboratorApplications = new HashSet<CollaboratorApplication>();
            Skills = new HashSet<Skill>();
            Collaborators = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public string? GithubUrl { get; set; }
        public int? Progress { get; set; }
        public int? CategoryId { get; set; }
        public string? CreatorName { get; set; }

        public virtual Category? Category { get; set; }
        public virtual User? Creator { get; set; }
        public virtual ICollection<CollaboratorApplication> CollaboratorApplications { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<User> Collaborators { get; set; }
    }
}
