using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCategoryCommand, Result>
{
    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, category);
        var result = unitOfWork.CategoryRepository.Delete(category);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);
        return result ? Result.Deleted() : Result.FailedDelete();
    }
}
