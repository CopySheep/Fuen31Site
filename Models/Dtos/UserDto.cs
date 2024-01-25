namespace Fuen31Site.Models.Dtos
{
    public class UserDto
    {
        public string? Name { get; set; }
        public int? Age { get; set; } = 29;
        public string? Email { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
