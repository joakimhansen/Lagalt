namespace Lagalt_backend.Data.DTOs.User {

    /// <summary>
    /// Used to change an existing user by username
    /// </summary>
    public class UserPutDTO {
        public string Username { get; set; } = null!;
        public string? Info { get; set; }
        public string? ImageUrl { get; set; }
        public bool Hidden { get; set; }
    }
}
