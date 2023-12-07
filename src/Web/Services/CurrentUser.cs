using System.Security.Claims;

using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Web.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string Id => httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)?? string.Empty;
}
