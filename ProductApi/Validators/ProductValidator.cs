using FluentValidation;
using ProductApi.Models;
using ProductApi.Resources;

namespace ProductApi.Validators
{
    public class ProductValidator:AbstractValidator<ProductResource>
    {
        public ProductValidator()
        {
            RuleFor(pn => pn.ProductName).NotNull().WithMessage("Please specify a Product name")
                .MaximumLength(50).WithMessage("Product name can be a maximum of 50 characters");
            RuleFor(p => p.Price).NotNull().WithMessage("Please specify a Product name");
            RuleFor(s => s.State).NotNull().WithMessage("Please specify a State")
                .MaximumLength(50).WithMessage("State can be a maximum of 50 characters");
        }
    }
}
