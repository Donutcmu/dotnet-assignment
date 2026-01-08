using Microsoft.EntityFrameworkCore;
using DotnetAssignment.Models;

namespace DotnetAssignment.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
