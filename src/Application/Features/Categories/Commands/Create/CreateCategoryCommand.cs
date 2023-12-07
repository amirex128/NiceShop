using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Commands.Create;

public record CreateCategoryCommand : IRequest<int>
{
    public string? Title { get; set; }
    public string? CategoryLine { get; set; }
    public string? PostalCode { get; set; }
    public int CityId { get; set; }
    public int ProvinceId { get; set; }
    public string? UserId { get; set; }
}

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
    }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category entity = new Category();

        _context.Categories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
