using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Users.Commands.ApproveOTP;

public record ApproveOtpUserCommand : IRequest<string>
{
}

public class ApproveOtpUserCommandValidator : AbstractValidator<ApproveOtpUserCommand>
{
    public ApproveOtpUserCommandValidator()
    {
    }
}

public class ApproveOtpUserCommandHandler : IRequestHandler<ApproveOtpUserCommand, string>
{
    private readonly IApplicationDbContext _context;

    public ApproveOtpUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(ApproveOtpUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new User
        {
        };

        _context.Users.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
