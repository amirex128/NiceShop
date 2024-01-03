using NiceShop.Application.Features.Categories.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Categories.Queries.GetById;

public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto>;
