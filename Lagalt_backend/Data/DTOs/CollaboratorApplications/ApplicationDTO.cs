﻿namespace Lagalt_backend.Data.DTOs.CollaboratorApplications {

    /// <summary>
    /// Defines an application-dto
    /// Used to get all collaboration-applications
    /// </summary>
    public class ApplicationDTO {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public string? User { get; set; }
        public int? Project { get; set; }
    }
}
