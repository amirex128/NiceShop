using NiceShop.Application.Features.Addresses.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Addresses.Queries.GetById;

public record GetAddressByIdQuery(int Id) : IRequest<AddressDto>;
