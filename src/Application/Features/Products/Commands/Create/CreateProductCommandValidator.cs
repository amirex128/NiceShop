using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator(IApplicationDbContext context)
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
        
        RuleFor(v => v.DiscountPercent)
            .InclusiveBetween(0, 100).WithMessage("DiscountPercent must be between 0 and 100.");

        RuleFor(v => v.Weight)
            .GreaterThanOrEqualTo(0).WithMessage("Weight must be greater than or equal to 0.");

        RuleFor(v => v.FreeSend)
            .NotNull().WithMessage("FreeSend is required.");

        RuleFor(v => v.HasGuarantee)
            .NotNull().WithMessage("HasGuarantee is required.");

        RuleFor(v => v.LongDescription)
            .MaximumLength(5000).WithMessage("LongDescription must not exceed 5000 characters.")
            .When(v => v.LongDescription != null);

        RuleFor(v => v.Barcode)
            .MaximumLength(200).WithMessage("Barcode must not exceed 200 characters.")
            .MustAsync(async (barcode, cancellationToken) =>
                !await context.Products.AnyAsync(p => p.Barcode == barcode, cancellationToken))
            .When(v => v.Barcode != null);

        RuleFor(v => v.Slug)
            .NotEmpty().WithMessage("Slug is required.")
            .MustAsync(async (slug, cancellationToken) =>
                !await context.Products.AnyAsync(p => p.Slug == slug, cancellationToken))
            .Matches(@"^[a-z0-9]+(?:-[a-z0-9]+)*$").WithMessage("Slug is not valid.");

        RuleForEach(v => v.SeoTags)
            .MaximumLength(100).WithMessage("SeoTag must not exceed 100 characters.")
            .When(v => v.SeoTags != null && v.SeoTags.Any());
        
        RuleFor(v => v.Status)
            .IsInEnum().WithMessage("Invalid Status.");

        RuleForEach(v => v.Categories)
            .GreaterThan(0).WithMessage("Category id must be greater than 0.")
            .MustAsync(async (id, cancellationToken) => await context.Categories.AnyAsync(c => c.Id == id, cancellationToken))
            .When(v => v.Categories != null && v.Categories.Any());

        RuleForEach(v => v.ProductVariants)
            .GreaterThan(0).WithMessage("ProductVariant id must be greater than 0.")
            .MustAsync(async (id, cancellationToken) => await context.ProductVariants.AnyAsync(p => p.Id == id, cancellationToken))
            .When(v => v.ProductVariants != null && v.ProductVariants.Any());
        

        RuleForEach(v => v.Medias)
            .GreaterThan(0).WithMessage("Media id must be greater than 0.")
            .MustAsync(async (id, cancellationToken) => await context.Medias.AnyAsync(m => m.Id == id, cancellationToken))
            .When(v => v.Medias != null && v.Medias.Any());

        RuleForEach(v => v.ProductAttributes)
            .GreaterThan(0).WithMessage("ProductAttribute id must be greater than 0.")
            .MustAsync(async (id, cancellationToken) => await context.ProductAttributes.AnyAsync(p => p.Id == id, cancellationToken))
            .When(v => v.ProductAttributes != null && v.ProductAttributes.Any());
    }
}
