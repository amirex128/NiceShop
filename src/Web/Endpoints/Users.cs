using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Identity;

namespace NiceShop.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        // app.MapGroup(this)
        //     .MapIdentityApi<User>();
    }
}
