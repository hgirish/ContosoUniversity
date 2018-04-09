using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Model
{
   public class Instructor
    {
        public int InstructorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public string FullName { get { return LastName + ", " + FirstName; } }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
