using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Wishlists.Commands.Delete;

public class DeleteWishlistCommandValidator : AbstractValidator<DeleteWishlistCommand>
{
    public DeleteWishlistCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Slug is required.")
            .Must((productId) =>
                !context.Products.Any(a => a.Id == productId)).WithMessage("Product id must be valid.");
    }
}
