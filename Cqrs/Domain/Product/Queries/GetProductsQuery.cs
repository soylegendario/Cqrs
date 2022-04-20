using Cqrs.Queries;

namespace Cqrs.Domain.Queries;

public class GetProductsQuery : IQuery
{
    public int FromId { get; set; }
    public int ToId { get; set; }
}