using NiceShop.Application.Common.Exceptions;
using NiceShop.Application.Features.Articles.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Articles.Queries.GetById;

public record GetArticleByIdQuery(int Id) : IRequest<ArticleDto>;
