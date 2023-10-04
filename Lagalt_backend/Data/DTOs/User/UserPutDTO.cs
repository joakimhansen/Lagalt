namespace Lagalt_backend.Data.DTOs.User
{
    public class UserPutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Info { get; set; }
    }
}
