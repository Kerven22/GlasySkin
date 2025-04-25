using FluentValidation;
using Shared.CreateDtos;

namespace Services.ProductService
{
    public class CreateProductCommandValidator : AbstractValidator<ProductRequestDto>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithErrorCode("Type Id is Empty!");
            RuleFor(c => c.Cost).Cascade(CascadeMode.Stop).NotEmpty()
                .GreaterThan(0).WithErrorCode(" Cost Can not bu minus!");
            RuleFor(c => c.Quantity).NotEmpty().WithErrorCode("Type Id is Empty!");
        }
    }
}
