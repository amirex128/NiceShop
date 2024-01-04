namespace NiceShop.Application.Features.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        When(v => v.Name != null, () =>
        {
            RuleFor(v => v.Name)
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
        });

        RuleFor(v => v.Description)
            .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.")
            .When(v => v.Description != null);

        RuleFor(v => v.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.")
            .When(v => v.Price.HasValue);

        RuleFor(v => v.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stock must be greater than or equal to 0.")
            .When(v => v.Stock.HasValue);

        RuleFor(v => v.Status)
            .IsInEnum().WithMessage("Invalid Status.")
            .When(v => v.Status.HasValue);

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
