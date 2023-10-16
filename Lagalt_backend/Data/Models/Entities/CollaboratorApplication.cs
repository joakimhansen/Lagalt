using System;
using System.Collections.Generic;

namespace Lagalt_backend.Data.Models.Entities {
    public partial class CollaboratorApplication {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public string? User { get; set; }
        public int? Project { get; set; }

        public virtual Project? ProjectNavigation { get; set; }
        public virtual User? UserNavigation { get; set; }
    }
}
