using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Categories.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Categories.Queries.GetById;

public class GetCategoryByIdHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Categories
            .Include(x => x.Medias)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<CategoryDto>(result);
    }
}
