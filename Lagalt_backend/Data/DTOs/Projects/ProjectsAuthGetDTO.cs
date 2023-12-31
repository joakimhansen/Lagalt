﻿using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Models.Entities;
using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.DTOs.Skills;

namespace Lagalt_backend.Data.DTOs.Projects {

    /// <summary>
    /// Used to get a project by id when authenticated/logged in
    /// </summary>
    public class ProjectsAuthGetDTO {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? FullDescription { get; set; }
        public CollaboratorDTO? Creator { get; set; }
        public ICollection<CollaboratorDTO> Collaborators { get; set; } = new List<CollaboratorDTO>();
        public ICollection<ApplicationDTO> Applications { get; set; } = new List<ApplicationDTO>();
        public string[] NeededSkills { get; set; } = new string[] { };
        public int? Progress { get; set; }
        public string? GithubUrl { get; set; }
    }
}
