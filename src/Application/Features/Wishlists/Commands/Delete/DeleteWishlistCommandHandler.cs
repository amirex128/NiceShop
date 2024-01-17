using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Wishlists.Commands.Delete;

public class DeleteWishlistCommandHandler(IApplicationDbContext context, IIdentityService identityService)
    : IRequestHandler<DeleteWishlistCommand, Result>
{
    public async Task<Result> Handle(DeleteWishlistCommand request, CancellationToken cancellationToken)
    {
        var user = await identityService.GetUserAsync();
        var product = await context.Products.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        user!.Wishlists.Remove(product!);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
