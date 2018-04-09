using ContosoUniversity.Data.Abstract;
using ContosoUniversity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContosoUniversity.Data.Repositories
{
    public class CoursesRepository : EntityBaseRepository<Course>, ICoursesRepository
    {
        private readonly ContosoContext _context;

        public CoursesRepository(ContosoContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Department> PopulateDepartmentDropdownList()
        {
            return _context.Departments.OrderBy(d => d.Name);
        }
    }
}
