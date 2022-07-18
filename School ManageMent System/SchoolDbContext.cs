using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManageMentSystem.Models;

namespace SchoolManageMentSystem
{
    public class SchoolDbContext:IdentityDbContext<ApplicationUser>

    {
       
        public SchoolDbContext(DbContextOptions<SchoolDbContext>options):base(options)
        {

        }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }

        public DbSet<BillsModel> Bills { get; set; }
        public DbSet<LeaveModel> Leaves { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DepartmentModel>().ToTable("Department");
            builder.Entity<AppointmentModel>().ToTable("Appointment");
            builder.Entity<BillsModel>().ToTable("Bills");
            builder.Entity<LeaveModel>().ToTable("Leave");

            base.OnModelCreating(builder);
        }
    }
}
