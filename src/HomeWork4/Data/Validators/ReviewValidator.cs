using Data.Validators.Interfaces;
using FluentValidation;
using Requests.Request;

namespace Data.Validators
{
    public class ReviewValidator: AbstractValidator<ReviewRequest>, IReviewRequestValidator
    {
        public ReviewValidator()
        {
            RuleFor(r => r.Mark)
                .GreaterThan(0).WithMessage("Mark is too low")
                .LessThan(6).WithMessage("Mark is too high");

            RuleFor(r => r.Comment)
                .MaximumLength(150).WithMessage("Comment is too long.");
        }
    }
}
