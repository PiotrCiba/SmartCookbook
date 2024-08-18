using Microsoft.AspNetCore.Identity;

namespace SmartCookbook.Models
{
    public class SmartCookbookUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
