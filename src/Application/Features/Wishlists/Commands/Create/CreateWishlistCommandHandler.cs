using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Wishlists.Commands.Create;

public class CreateWishlistCommandHandler(IApplicationDbContext context, IIdentityService identityService)
    : IRequestHandler<CreateWishlistCommand, Result>
{
    public async Task<Result> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
    {
        var user = await identityService.GetUserAsync();
        var product =
            await context.Products.SingleOrDefaultAsync(x => x.Id == request.ProductId,
                cancellationToken: cancellationToken);
        user!.Wishlists.Add(product!);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
