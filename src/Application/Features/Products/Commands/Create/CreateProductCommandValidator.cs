namespace NiceShop.Application.Features.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

        RuleFor(v => v.Description)
            .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");

        RuleFor(v => v.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(v => v.Stock)
            .NotEmpty().WithMessage("Stock is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Stock must be greater than or equal to 0.");

        RuleFor(v => v.Status)
            .IsInEnum().WithMessage("Invalid Status.");

        RuleForEach(v => v.Categories)
            .GreaterThan(0).WithMessage("Category id must be greater than 0.")
            .When(v => v.Categories != null && v.Categories.Any());

        RuleForEach(v => v.ProductVariants)
            .GreaterThan(0).WithMessage("ProductVariant id must be greater than 0.")
            .When(v => v.ProductVariants != null && v.ProductVariants.Any());
        

        RuleForEach(v => v.Medias)
            .GreaterThan(0).WithMessage("Media id must be greater than 0.")
            .When(v => v.Medias != null && v.Medias.Any());

        RuleForEach(v => v.ProductAttributes)
            .GreaterThan(0).WithMessage("ProductAttribute id must be greater than 0.")
            .When(v => v.ProductAttributes != null && v.ProductAttributes.Any());

        RuleForEach(v => v.ProductReviews)
            .GreaterThan(0).WithMessage("ProductReview id must be greater than 0.")
            .When(v => v.ProductReviews != null && v.ProductReviews.Any());
    }
}
