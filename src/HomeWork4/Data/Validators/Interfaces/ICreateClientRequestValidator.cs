using FluentValidation;
using Requests.Request;

namespace Data.Validators
{
    public interface ICreateClientRequestValidator : IValidator<CreateClientRequest>
    {
    }
}
