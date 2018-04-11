using System;
using System.Collections.Generic;
using System.Text;
using ContosoUniversity.Model;
using ContosoUniversity.Model.ViewModels;

namespace ContosoUniversity.Data.Abstract {
    public interface IInstructorsRepository : IEntityBaseRepository<Instructor> {
        IEnumerable<Instructor> GetAllInstructors();
        IEnumerable<AssignedCourseViewModel> GetAssignedCourses(Instructor instructor);
    }
}
