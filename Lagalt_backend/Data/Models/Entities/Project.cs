using System;
using System.Collections.Generic;

namespace Lagalt_backend.Data.Models.Entities
{
    public partial class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public int? CategoryId { get; set; }
        public int? CreatorId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual User? Creator { get; set; }
    }
}
