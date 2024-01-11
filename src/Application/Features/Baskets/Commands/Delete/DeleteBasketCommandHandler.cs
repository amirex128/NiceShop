using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Baskets.Commands.Delete;

public class DeleteBasketCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteBasketCommand, Result>
{
    public async Task<Result> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        var result = await context.Baskets.Where(b => b.Id < 3).ExecuteDeleteAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
