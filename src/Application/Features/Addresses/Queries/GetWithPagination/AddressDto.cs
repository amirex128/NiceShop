using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Queries.GetWithPagination;

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
