using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Model.ViewModels
{
   public class AssignedCourseViewModel
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}
