using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Queries.GetWithPagination;

public class AddressDto
{
    public int Id { get; init; }
    public string? Title { get; set; }
    public required string AddressLine { get; set; }
    public required string PostalCode { get; set; }

    public required City City { get; set; }
    public required Province Province { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Pagination<Address>, Pagination<AddressDto>>()
                .ForMember(dest => 
                    dest.Items, opt => 
                    opt.MapFrom(src => src.Items));
        }
    }
}
