using NiceShop.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace NiceShop.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.OperationSuccess()
            : Result.OperationFailed(result.Errors.Select(e => e.Description).ToArray());
    }
}
