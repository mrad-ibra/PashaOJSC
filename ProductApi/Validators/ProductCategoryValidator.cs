using FluentValidation;
using ProductApi.Models;

namespace ProductApi.Validators
{
    public class ProductCategoryValidator : AbstractValidator<ProductCategory>
    {
        public ProductCategoryValidator()
        {
            RuleFor(p=>p.ProductCategoryName).NotNull().WithMessage("Please specify a Category name")
                .MaximumLength(50).WithMessage("Category name can be a maximum of 50 characters");
        }
    }
}
