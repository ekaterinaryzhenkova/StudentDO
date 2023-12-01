using Data.Validators.Interfaces;
using FluentValidation;
using Requests.Request;
using System.Text.RegularExpressions;

namespace Data.Validators
{
    public class CreateClientValidator: AbstractValidator<CreateClientRequest>, ICreateClientRequestValidator
    {
        private static Regex NameRegex = new(@"^[A-Za-zА-Яа-я]+\s[A-Za-zА-Яа-я]+$");

        public CreateClientValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Must(x => NameRegex.IsMatch(x));

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Number cannot be empty.")
                .Must(c => c.Length == 11);
        }
    }
}
