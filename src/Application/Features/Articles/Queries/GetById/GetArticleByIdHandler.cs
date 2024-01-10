using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Articles.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Articles.Queries.GetById;

public class GetArticleByIdHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetArticleByIdQuery, ArticleDto>
{
    public async Task<ArticleDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Articles
            .Include(x => x.Categories)
            .Include(x => x.Medias)
            .SingleOrDefaultAsync(x => x.Id == request.Id);

        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<ArticleDto>(result);
    }
}
