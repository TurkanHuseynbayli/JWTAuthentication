using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
