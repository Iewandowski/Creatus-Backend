using Microsoft.EntityFrameworkCore;
using creatus_backend.Models;

namespace creatus_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();

            if (!Users.Any())
            {
                Users.Add(new User
                {
                    Name = "Admin",
                    Email = "admin@example.com",
                    Password = "admin@123",
                    Level = 5
                });

                SaveChanges();
            }
        }
        public DbSet<User> Users { get; set; }
    }
}
