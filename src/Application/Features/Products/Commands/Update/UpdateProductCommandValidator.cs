using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(v => v.Name)
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
            .When(v => v.Name != null);
        
        RuleFor(v => v.Description)
            .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.")
            .When(v => v.Description != null);

        RuleFor(v => v.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.")
            .When(v => v.Price.HasValue);

        RuleFor(v => v.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stock must be greater than or equal to 0.")
            .When(v => v.Stock.HasValue);
              
        RuleFor(v => v.DiscountPercent)
            .InclusiveBetween(0, 100).WithMessage("DiscountPercent must be between 0 and 100.")
            .When(v => v.DiscountPercent.HasValue);

        RuleFor(v => v.Weight)
            .GreaterThanOrEqualTo(0).WithMessage("Weight must be greater than or equal to 0.")
            .When(v => v.Weight.HasValue);

        RuleFor(v => v.FreeSend)
            .NotNull().WithMessage("FreeSend is required.")
            .When(v => v.FreeSend.HasValue);
        
        RuleFor(v => v.HasGuarantee)
            .NotNull().WithMessage("HasGuarantee is required.")
            .When(v => v.HasGuarantee.HasValue);

        RuleFor(v => v.LongDescription)
            .MaximumLength(5000).WithMessage("LongDescription must not exceed 5000 characters.")
            .When(v => v.LongDescription != null);

        RuleFor(v => v.Barcode)
            .MaximumLength(200).WithMessage("Barcode must not exceed 200 characters.")
            .Must((barcode) =>
                !context.Products.Any(p => p.Barcode == barcode)).WithMessage("Barcode is not unique.")
            .When(v => v.Barcode != null);

        RuleFor(v => v.Slug)
            .NotEmpty().WithMessage("Slug is required.")
            .Matches(@"^[a-z0-9]+(?:-[a-z0-9]+)*$").WithMessage("Slug is not valid.")
            .When(v => v.Slug != null);

        RuleForEach(v => v.SeoTags)
            .MaximumLength(100).WithMessage("SeoTag must not exceed 100 characters.")
            .When(v => v.SeoTags != null && v.SeoTags.Any());
        
        RuleFor(v => v.Status)
            .IsInEnum().WithMessage("Invalid Status.")
            .When(v => v.Status.HasValue);

        RuleForEach(v => v.Categories)
            .GreaterThan(0).WithMessage("Category id must be greater than 0.")
            .Must((id) => context.Categories.Any(c => c.Id == id)).WithMessage("Category id is not valid.")
            .When(v => v.Categories != null && v.Categories.Any());

        RuleForEach(v => v.ProductVariants)
            .GreaterThan(0).WithMessage("ProductVariant id must be greater than 0.")
            .Must((id) => context.ProductVariants.Any(p => p.Id == id)).WithMessage("ProductVariant id is not valid.")
            .When(v => v.ProductVariants != null && v.ProductVariants.Any());

        RuleForEach(v => v.Medias)
            .GreaterThan(0).WithMessage("Media id must be greater than 0.")
            .Must((id) => context.Medias.Any(m => m.Id == id)).WithMessage("Media id is not valid.")
            .When(v => v.Medias != null && v.Medias.Any());

        RuleForEach(v => v.ProductAttributes)
            .GreaterThan(0).WithMessage("ProductAttribute id must be greater than 0.")
            .Must((id) => context.ProductAttributes.Any(p => p.Id == id)).WithMessage("ProductAttribute id is not valid.")
            .When(v => v.ProductAttributes != null && v.ProductAttributes.Any());

    }
}
