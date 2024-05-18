using FluentValidation;
using SaleKiosk.SharedKernel.Dto;

namespace SaleKiosk.Application.Validators
{
    public class RegisterUpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public RegisterUpdateProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(p => p.Desc)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(p => p.UnitPrice)
                .GreaterThan(0);

            
        }

    }
}
