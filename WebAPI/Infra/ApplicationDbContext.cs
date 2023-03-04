using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebAPI.Domain.Models;

namespace WebAPI.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<Company>().HasKey(x => x.Id);

            modelBuilder.Entity<Employee>().Property(e => e.Name).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Age).IsRequired();

            modelBuilder.Entity<Company>().Property(c => c.Name).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Company>().Property(c => c.Address).HasMaxLength(255).IsRequired();

            //Configurando o Relacionamento

            modelBuilder.Entity<Company>()
            .HasMany(x=>x.Employees)
            .WithOne(x=>x.CurrentCompany)
            .IsRequired();


            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
