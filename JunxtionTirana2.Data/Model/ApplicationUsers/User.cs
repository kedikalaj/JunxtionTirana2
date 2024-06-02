using Microsoft.AspNetCore.Identity;

namespace JunxtionTirana2.Model.ApplicationUsers
{
    public class User : IdentityUser<Guid>
    {
        public int AvatarId { get; set; }
        public string? Education { get; set; }
        public string? Description { get; set; }
        public List<string>? Skills { get; set; }
    }
}
