using System.Security.Claims;
using NiceShop.Application.AI.Common.Interfaces;

namespace NiceShop.Web.AI.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string Id => httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)?? string.Empty;
}
