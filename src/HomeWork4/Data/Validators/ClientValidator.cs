using FluentValidation;
using Requests.Request;
using System.Text.RegularExpressions;

namespace Data.Validators
{
    public class ClientValidator: AbstractValidator<ClientRequest>, IClientRequestValidator
    {
        private static Regex NameRegex = new(@"^[A-Za-zА-Яа-я]+\s[A-Za-zА-Яа-я]+$");

        public ClientValidator()
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
