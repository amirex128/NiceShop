using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Categories.Queries.GetWithPagination
{
    public record GetCategoriesWithPaginationQuery : IRequest<PaginatedList<CategoryDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetCategoriesWithPaginationQueryHandler : IRequestHandler<GetCategoriesWithPaginationQuery, PaginatedList<CategoryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CategoryDto>> Handle(GetCategoriesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult<PaginatedList<CategoryDto>>(null!);
        }
    }
}
