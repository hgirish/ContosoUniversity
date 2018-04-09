using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Model.ViewModels.Validations
{
  public  class CourseViewModelValidator : AbstractValidator<CourseViewModel>
    {
        public CourseViewModelValidator()
        {
            RuleFor(s => s.Title)
                .Length(3, 50)
                .WithMessage("Title must be longer than 3 and less than 50 characters.");
            RuleFor(s => s.Credits)
                .InclusiveBetween(0, 50)
                .WithMessage("Value must be number between 0 and 50");
        }
    }
}
