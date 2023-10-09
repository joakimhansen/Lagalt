namespace Lagalt_backend.Data.DTOs.User
{
    public class UserPutDTO
    {
        public string Username { get; set; } = null!;
        public string? Info { get; set; }
        public string? ImageUrl { get; set; }
        public bool Hidden { get; set; }
    }
}
