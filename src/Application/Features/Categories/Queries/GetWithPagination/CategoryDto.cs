using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Queries.GetWithPagination;

public class CategoryDto
{
    public int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
