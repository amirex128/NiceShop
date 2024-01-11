using NiceShop.Application.Features.Baskets.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Baskets.Queries.GetById;

public record GetBasketByIdQuery(int Id) : IRequest<BasketDto>;
