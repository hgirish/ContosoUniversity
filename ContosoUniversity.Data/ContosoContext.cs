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
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Course>().ToTable("Course");
            builder.Entity<Enrollment>().ToTable("Enrollment");
            builder.Entity<Student>().ToTable("Student");
           // builder.Entity<Department>().ToTable("Department");
            builder.Entity<Instructor>().ToTable("Instructor");
            builder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            builder.Entity<CourseAssignment>().ToTable("CourseAssignment");


            builder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });

            builder.Entity<OfficeAssignment>()
                .HasKey(o => new { o.InstructorID });
        }
    }
}
