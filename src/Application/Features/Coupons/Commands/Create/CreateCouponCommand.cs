using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Coupons.Commands.Create;

public record CreateCouponCommand : IRequest<int>
{
}

public class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
{
    public CreateCouponCommandValidator()
    {
    }
}

public class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCouponCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
    {
        var entity = new CouponPercentage()
        {
            UserId = "",
            Code = ""
        };

        _context.CouponPercentage.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
