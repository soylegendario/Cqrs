using Cqrs.Queries;

namespace Cqrs.Domain.Queries;

public class GetProducts : IQuery
{
    public int FromId { get; set; }
    public int ToId { get; set; }
}