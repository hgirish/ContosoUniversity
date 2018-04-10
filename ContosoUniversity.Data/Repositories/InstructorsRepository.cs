using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContosoUniversity.Data.Abstract;
using ContosoUniversity.Model;
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
    }
}
