using Data.Validators.Interfaces;
using FluentValidation;
using Requests.Request;
using System.Text.RegularExpressions;

namespace Data.Validators
{
    public class SessionValidator : AbstractValidator<SessionRequest>, ISessionRequestValidator
    {
        private static Regex GuidRegex = new(@"^(?:\{?[A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12}\}?)$");

        public SessionValidator()
        {
            RuleFor(s => s.ClientId)
                .Must(x => !GuidRegex.IsMatch(x.ToString()));

            RuleFor(s => s.MasseurId)
                .Must(x => !GuidRegex.IsMatch(x.ToString()));

            RuleFor(s => s.TypeOfMassage)
                .NotEmpty().WithMessage("Type cannot be empty.")
                .MaximumLength(70).WithMessage("Type is too long.");
        }
    }
}
