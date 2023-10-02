using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_backend.Models.Entities
{

    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Info { get; set; } = null!;
    }
}
