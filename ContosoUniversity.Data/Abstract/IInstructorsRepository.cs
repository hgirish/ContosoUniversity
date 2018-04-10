using System;
using System.Collections.Generic;
using System.Text;
using ContosoUniversity.Model;

namespace ContosoUniversity.Data.Abstract {
    public interface IInstructorsRepository : IEntityBaseRepository<Instructor> {
        IEnumerable<Instructor> GetAllInstructors();
    }
}
