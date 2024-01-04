using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Addresses.Commands.Create;

public record CreateAddressCommand : IRequest<Result>
{
    public string? Title { get; set; }
    public required string AddressLine { get; set; }
    public required string PostalCode { get; set; }
    public int CityId { get; set; }
    public int ProvinceId { get; set; }
}
