using Cqrs.Queries;

namespace Cqrs.Repositories.Queries;

public class GetProductsQuery : IQuery
{
    public int FromId { get; set; }
    public int ToId { get; set; }
}