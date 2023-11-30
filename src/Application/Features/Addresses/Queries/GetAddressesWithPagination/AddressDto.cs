using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Queries.GetAddressesWithPagination;

public class AddressDto
{
    public int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Address, AddressDto>();
        }
    }
}
