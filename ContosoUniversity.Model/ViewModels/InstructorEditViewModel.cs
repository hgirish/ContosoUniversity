using ContosoUniversity.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Model.ViewModels
{
  public  class InstructorEditViewModel : IInstructor
    {
        public int InstructorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public string Office { get; set; }
        public IEnumerable<AssignedCourseViewModel> AssignedCourses { get; set; }
    }
}
