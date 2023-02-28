using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=employee_sample;Username=root;Password=1234");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
