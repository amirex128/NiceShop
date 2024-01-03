using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Articles.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Articles.Queries.GetById;

public class GetArticleByIdHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<GetArticleByIdQuery, ArticleDto>
{

    public async Task<ArticleDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.ArticleRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<ArticleDto>(result);
    }
}
