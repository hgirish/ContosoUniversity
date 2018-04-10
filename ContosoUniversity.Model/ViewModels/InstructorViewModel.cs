using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ContosoUniversity.Model.Interfaces;
using ContosoUniversity.Model.ViewModels.Validations;

namespace ContosoUniversity.Model.ViewModels
{
    public class InstructorViewModel : IInstructor, IValidatableObject {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public string Office { get; set; }
        public string[] SelectedCourses { get; set; }

        public ICollection<CourseViewModel> Courses { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new InstructorViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item =>
            new ValidationResult(item.ErrorMessage,
            new[] { item.PropertyName }));
        }
    }
}
