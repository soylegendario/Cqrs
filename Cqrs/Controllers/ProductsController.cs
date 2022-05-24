using Cqrs.Commands;
using Cqrs.Domain;
using Cqrs.Queries;
using Cqrs.Repositories.Commands;
using Cqrs.Repositories.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : Controller
{
    private readonly ICommandDispatcher _commandDispatcher;

    private readonly IQueryDispatcher _queryDispatcher;

    public ProductsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    [Route("{fromId:int}/{toId:int}")]
    public async Task<IActionResult> Get(int fromId = 1, int toId = 10)
    {
        var query = new GetProductsQuery
        {
            FromId = fromId,
            ToId = toId
        };
        var products = await _queryDispatcher.DispatchAsync<GetProductsQuery, IEnumerable<Product>>(query);
        return Ok(products);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
}