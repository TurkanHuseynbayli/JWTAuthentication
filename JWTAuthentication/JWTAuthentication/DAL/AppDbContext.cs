using JWTAuthentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.DAL
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Student>().HasData(
                new Student{Id = 1, Name = "Turkan",Surname = "Huseynbeyli",Age = 23,Address = "20 yanvar"},
                new Student{Id = 2, Name = "Sona",Surname = "Yusifli",Age = 23,Address = "20 yanvar"}
                );
        }
    }
}
