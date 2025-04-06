using FluentValidation;
using FluentValidation.Results;

namespace Services.ProductService
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.TypeId).NotEmpty().WithErrorCode("Type Id is Empty!");
            RuleFor(c => c.Name).NotEmpty().WithErrorCode("Name is Empty!");
        }
    }
}
