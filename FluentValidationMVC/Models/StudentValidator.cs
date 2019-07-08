using FluentValidation;
using System;

namespace FluentValidationMVC.Models
{
    public class StudentValidator: AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Student Name is required");

            RuleFor(x => x.StudentDOB).NotEmpty().WithMessage("Student DOB is required");

            RuleFor(x => x.StudentEmailID).NotEmpty().WithMessage("Student EmailID is required");

            RuleFor(x => x.StudentFees).NotEmpty().WithMessage("Student Fees is required");

            RuleFor(x => x.StudentAddress).NotEmpty().WithMessage("Student Address is required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password is required");

            RuleFor(x => x.StudentDOB).Must(AgeValidate).WithMessage("Invalid date student age must be 21 or greater than 21");

            RuleFor(x => x.StudentEmailID).EmailAddress().WithMessage("Student EmailID is required");

            RuleFor(x => x.StudentFees).InclusiveBetween(0, 50000);

            RuleFor(x => x.StudentAddress).Length(10, 250).WithMessage("Address must be between 10 to 250 words");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Password do not Match");
        }


        private bool AgeValidate(DateTime value)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - Convert.ToDateTime(value).Year;
            if (age < 21)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }


}