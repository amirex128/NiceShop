using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Categories.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Categories.Queries.GetById;

public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto>;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoryByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories.Where(x => x.Id == request.Id)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
        Guard.Against.NotFound(request.Id, result);
        return result;
    }
}
