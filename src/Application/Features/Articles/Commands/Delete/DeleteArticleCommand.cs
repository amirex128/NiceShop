using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Articles.Commands.Delete;

public record DeleteArticleCommand(int Id) : IRequest<Result>;
