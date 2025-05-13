using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Models
{
    public class ProjectEntity:IdentityDbContext<ApplicationUser>
    {
        public ProjectEntity() 
        {

        }
        public ProjectEntity(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MyDatabase;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
