using FluentValidation.Results;

namespace Data.Validators
{
  public interface IValidator<T> where T : class
  {
    ValidationResult Validate(T request);
  }
}
