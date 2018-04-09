using ContosoUniversity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Data
{
   public class ContosoContext : IdentityDbContext<ApplicationUser>
    {
        public ContosoContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });

            builder.Entity<OfficeAssignment>()
                .HasKey(o => new { o.InstructorID });
        }
    }
}
