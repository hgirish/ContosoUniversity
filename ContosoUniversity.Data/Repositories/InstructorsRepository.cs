using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContosoUniversity.Data.Abstract;
using ContosoUniversity.Model;
using ContosoUniversity.Model.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data.Repositories
{
    public class InstructorsRepository : EntityBaseRepository<Instructor>, IInstructorsRepository {
        private readonly ContosoContext _context;

        public InstructorsRepository(ContosoContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Instructor> GetAllInstructors()
        {
            var result = _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                .ThenInclude(i => i.Course)
                .AsNoTracking()
                .OrderBy(i => i.LastName);

            return result;
        }

        public IEnumerable<AssignedCourseViewModel> GetAssignedCourses(Instructor instructor)
        {
            var allCourses = _context.Courses;
            var instructorCourses = new HashSet<int>(instructor.CourseAssignments
                .Select(c => c.CourseID));
            var viewModel = new List<AssignedCourseViewModel>();

            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseViewModel
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }

            return viewModel;

        }
    }
}
