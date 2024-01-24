using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Products.Queries.GetWithPagination;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Users.Queries.Info;

public class UserInfoQueryHandler(IIdentityService identityService, IMapper mapper)
    : IRequestHandler<UserInfoQuery, UserDto?>
{
    public async Task<UserDto?> Handle(UserInfoQuery request, CancellationToken cancellationToken)
    {
        User? user = await identityService.GetUserAsync();

        if (user is null)
        {
            return null;
        }

        return mapper.Map<UserDto>(user);
    }
}
