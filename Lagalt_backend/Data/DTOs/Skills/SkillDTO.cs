namespace Lagalt_backend.Data.DTOs.Skills
{
    public class SkillDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int[] UserIds { get; set; } = null!;
    }
}
