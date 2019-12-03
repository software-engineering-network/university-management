using FluentValidation;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class CreateApplicationValidator : AbstractValidator<CreateApplication>
    {
        public CreateApplicationValidator()
        {
            RuleFor(x => x.ApplicantName)
                .NotEmpty()
                .WithMessage("First name is required");

            RuleFor(x => x.ApplicantSurname)
                .NotEmpty()
                .WithMessage("Last name is required");
                
            RuleFor(x => x.ApplicantSocialSecurityNumber)
                .NotNull()
                .WithMessage("SSN is required")
                .Matches(@"^\d{3}-\d{2}-\d{4}$")
                .WithMessage("Invalid SSN");

            RuleFor(x => x.ProgramId)
                .Must(x => x != 0)
                .WithMessage("Program is required");
        }
    }
}
