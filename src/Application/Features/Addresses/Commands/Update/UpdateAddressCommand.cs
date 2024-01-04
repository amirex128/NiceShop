using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Addresses.Commands.Update;

public record UpdateAddressCommand : IRequest<Result>
{
    public required int Id { get; init; }
    public string? Title { get; set; }
    public string? AddressLine { get; set; }
    public string? PostalCode { get; set; }
    public int? CityId { get; set; }
    public int? ProvinceId { get; set; }
}
