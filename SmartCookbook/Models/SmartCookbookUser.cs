using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace SmartCookbook.Models
{
    public class SmartCookbookUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
