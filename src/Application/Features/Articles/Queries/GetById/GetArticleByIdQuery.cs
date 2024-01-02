using NiceShop.Application.Common.Exceptions;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Articles.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Articles.Queries.GetById;

public record GetArticleByIdQuery(int Id) : IRequest<ArticleDto>;

public class GetArticleByIdHandler : IRequestHandler<GetArticleByIdQuery, ArticleDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArticleByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ArticleDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Articles.Where(x => x.Id == request.Id)
            .ProjectTo<ArticleDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
        
        Guard.Against.NotFound(request.Id, result);
        
        return result;
    }
}
