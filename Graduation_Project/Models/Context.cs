using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Models
{
    public class Context:IdentityDbContext<ApplicationUser>
    {

        public Context()
        {

        }
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SpareParts> SpareParts { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Admin>().HasData(
       new Admin {ID=-1, Name = "ahmed mohamed", Phone = "01007889901", Email = "AHmed22@gmail.com", Password = "AHmed22@gmail.com" }
       );
        }
        }
    }
