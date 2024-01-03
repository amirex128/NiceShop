using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Categories.Commands.Delete;

public record DeleteCategoryCommand(int Id) : IRequest<Result>;
