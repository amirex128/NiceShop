using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Categories.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Categories.Queries.GetById;

public class GetCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<CategoryDto>(result);
    }
}
