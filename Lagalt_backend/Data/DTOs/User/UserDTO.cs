﻿using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.DTOs.Projects;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Data.DTOs.User {

    /// <summary>
    /// Used to get a spesific user by username
    /// </summary>
    public class UserDTO {
        public string Username { get; set; } = null!;
        public string? Info { get; set; }
        public string? ImageUrl { get; set; }
        public bool Hidden { get; set; }
        public ICollection<ProjectUserDTO> Projects { get; set; } = new List<ProjectUserDTO>();
        public string[] Skills { get; set; } = new string[] { };
        public ICollection<ApplicationAcceptDTO> Applications { get; set; } = new List<ApplicationAcceptDTO>();
    }
}
