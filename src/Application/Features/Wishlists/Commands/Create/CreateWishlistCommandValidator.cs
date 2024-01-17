using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Wishlists.Commands.Create;

public class CreateWishlistCommandValidator : AbstractValidator<CreateWishlistCommand>
{
    public CreateWishlistCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.ProductId)
            .NotEmpty().WithMessage("Slug is required.")
            .Must((productId) =>
                !context.Products.Any(a => a.Id == productId)).WithMessage("Product id must be valid.");
    }
}
