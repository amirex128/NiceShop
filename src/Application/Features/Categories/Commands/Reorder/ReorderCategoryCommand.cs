using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Categories.Commands.Reorder;

public record ReorderCategoryCommand : IRequest<Result>
{
    public int Id { get; set; }
    public int Order { get; set; }
}
