using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContosoUniversity.Model
{
  public  class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<Enrollment>  Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }

    }
}
