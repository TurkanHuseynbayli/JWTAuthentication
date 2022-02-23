using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Models
{
    public class Credit
    {
        [Required]
        public double Money { get; set; }
        public int Percent { get; set; }
        public int Mounth { get; set; }
    }
}
