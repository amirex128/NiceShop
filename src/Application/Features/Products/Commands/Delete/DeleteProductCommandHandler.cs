using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Products.Commands.Delete;

public class DeleteProductCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, Result>
{
    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var article = await unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, article);
        var result = unitOfWork.ProductRepository.Delete(article);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);
        return result ? Result.Deleted() : Result.FailedDelete();
    }
}
