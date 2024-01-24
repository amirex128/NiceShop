using NiceShop.Application.Features.Products.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Users.Queries.Info;

public record UserInfoQuery : IRequest<UserDto?>;
