using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Model
{
  public  class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
