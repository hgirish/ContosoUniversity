using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Model.Interfaces
{
   public class IInstructor
    {
        int ID { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        DateTime HireDate { get; set; }
        string Office { get; set; }
    }
}
