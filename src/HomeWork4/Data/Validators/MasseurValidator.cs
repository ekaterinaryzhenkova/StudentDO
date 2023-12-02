using Data.Validators.Interfaces;
using FluentValidation;
using Requests.Request;
using System.Text.RegularExpressions;

namespace Data.Validators
{
    public class MasseurValidator: AbstractValidator<MasseurRequest>, IMasseurRequestValidator
    {
        private static Regex NameRegex = new(@"^[A-Za-zА-Яа-я]+\s[A-Za-zА-Яа-я]+$");

        public MasseurValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Must(x => !NameRegex.IsMatch(x));

            RuleFor(m => m.Specialization)
                .NotEmpty().WithMessage("Specialization cannot be empty.")
                .MaximumLength(70).WithMessage("Specialization is too long.");
        }
    }
}
