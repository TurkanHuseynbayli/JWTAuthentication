using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
