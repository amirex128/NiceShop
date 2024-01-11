
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Queries.GetCities;

public record GetCitiesByNameQuery(string? Name,int? ProvinceId) : IRequest<List<City>>;
