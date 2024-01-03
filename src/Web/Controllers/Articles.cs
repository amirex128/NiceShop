using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Articles.Commands.Create;
using NiceShop.Application.Features.Articles.Commands.Delete;
using NiceShop.Application.Features.Articles.Commands.Update;
using NiceShop.Application.Features.Articles.Queries.GetById;
using NiceShop.Application.Features.Articles.Queries.GetWithPagination;
using NiceShop.Domain.Constants;

namespace NiceShop.Web.Controllers;

public class Articles(IMediator mediator) : ApiController
{
    
    [HttpGet]
    [Authorize(Policy = ACL.CanGetAll)]
    public async Task<ActionResult<PaginatedList<ArticleDto>>> GetAll([FromQuery] GetArticlesWithPaginationQuery query)
    {
        return await mediator.Send(query);
    }
    
    [HttpGet("{id}")]
    [Authorize(Policy = ACL.CanGet)]
    public async Task<ActionResult<ArticleDto>> Get(int id)
    {
        return await mediator.Send(new GetArticleByIdQuery(id));
    }
    
    [HttpPost]
    [Authorize(Policy = ACL.CanCreate)]
    public async Task<ActionResult<int>> Create([FromBody] CreateArticleCommand command)
    {
        return await mediator.Send(command);
    }
    
    [HttpPut]
    [Authorize(Policy = ACL.CanUpdate)]
    public async Task<ActionResult>Update([FromBody]UpdateArticleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [Authorize(Policy = ACL.CanDelete)]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteArticleCommand(id));
        return NoContent();
    }
}

