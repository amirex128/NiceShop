using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Coupons.Commands.Update;

public record UpdateCouponCommand : IRequest<bool>
{
    public int Id { get; init; }
}

public class UpdateCouponCommandValidator : AbstractValidator<UpdateCouponCommand>
{
    public UpdateCouponCommandValidator()
    {
    }
}

public class UpdateCouponCommandHandler : IRequestHandler<UpdateCouponCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCouponCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.CouponPercentage
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
        
    }
}
