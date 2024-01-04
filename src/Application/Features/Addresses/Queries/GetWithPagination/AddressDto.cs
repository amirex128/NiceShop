using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Addresses.Queries.GetWithPagination;
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
            CreateMap<PaginatedList<Address>, PaginatedList<AddressDto>>()
                .ConvertUsing((source, destination, context) =>
                    new PaginatedList<AddressDto>
                    {
                        PageNumber = source.PageNumber,
                        TotalPages = source.TotalPages,
                        TotalCount = source.TotalCount,
                        Items = source.Items?.Select(item => context.Mapper.Map<AddressDto>(item)).ToList()
                    });
        }
    }
}
