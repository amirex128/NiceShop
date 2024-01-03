using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand, Result>
{
    public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.CategoryRepository.AddAsync(new Category
        {
            Name = request.Name,
            ParentCategoryId = request.ParentCategoryId,
            Description = request.Description,
            SeoTags = request.SeoTags,
            Medias = request.Medias?.Select(id => new Media { Id = id }).ToList(),
        });
        result = result && await unitOfWork.SaveChangesAsync();
        return result ? Result.Created() : Result.FailedCreate();
    }
}
