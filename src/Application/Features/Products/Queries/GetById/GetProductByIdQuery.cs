using NiceShop.Application.Features.Products.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Products.Queries.GetById;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
