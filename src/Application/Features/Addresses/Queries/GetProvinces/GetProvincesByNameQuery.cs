using NiceShop.Application.Features.Addresses.Queries.GetWithPagination;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Queries.GetProvinces;

public record GetProvincesByNameQuery(string? Name) : IRequest<List<Province>>;
