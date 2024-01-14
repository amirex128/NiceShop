using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Categories.Commands.Reorder;

public class ReorderCategoryCommandValidator : AbstractValidator<ReorderCategoryCommand>
{
    public ReorderCategoryCommandValidator(IApplicationDbContext context)
    {
      RuleFor(v => v.Id)
        .GreaterThan(0).WithMessage("Id must be greater than 0.")
        .Must((id) => context.Categories.Any(c => c.Id == id)).WithMessage("Id does not exist.");
      
      RuleFor(v => v.Order)
        .GreaterThan(0).WithMessage("Order must be greater than 0.");
    }
}
