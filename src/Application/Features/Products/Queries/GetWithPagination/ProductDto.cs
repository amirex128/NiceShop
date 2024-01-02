using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Products.Queries.GetWithPagination;

public class ProductDto
{
    public int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
