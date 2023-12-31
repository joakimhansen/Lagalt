﻿using Lagalt_backend.Data.DTOs.Categories;
using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.DTOs.Skills;
using Lagalt_backend.Data.DTOs.User;

namespace Lagalt_backend.Data.DTOs.Projects {

    /// <summary>
    /// Used to get all projects
    /// </summary>
    public class ProjectsListDTO {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public CategoriesGetDTO? Category { get; set; }
        public CollaboratorDTO? Creator { get; set; }
        public ICollection<CollaboratorDTO> Collaborators { get; set; } = new List<CollaboratorDTO>();
        public ICollection<ApplicationDTO> Applications { get; set; } = new List<ApplicationDTO>();
        public string[] NeededSkills { get; set; } = new string[] { };
    }
}
