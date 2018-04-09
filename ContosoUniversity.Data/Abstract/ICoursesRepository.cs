using ContosoUniversity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Data.Abstract
{
  public  interface ICoursesRepository : IEntityBaseRepository<Course>
    {
        IEnumerable<Department> PopulateDepartmentDropdownList();
    }
}
