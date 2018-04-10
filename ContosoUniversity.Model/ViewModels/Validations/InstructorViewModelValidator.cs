using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace ContosoUniversity.Model.ViewModels.Validations
{
   public class InstructorViewModelValidator : AbstractValidator<InstructorViewModel>
    {
        public InstructorViewModelValidator()
        {
            RuleFor(s => s.LastName).Length(1, 50)
                .WithMessage("Last name cannot be longer than 50 charactres");
            RuleFor(s => s.FirstName).Length(1, 50)
                .WithMessage("First name cannot be longer than 50 charactres");
            RuleFor(s => s.LastName).NotEmpty()
                .WithMessage("Last name cannot be empty");
            RuleFor(s => s.FirstName).NotEmpty()
                .WithMessage("First name cannot be empty");
        }
    }
}
