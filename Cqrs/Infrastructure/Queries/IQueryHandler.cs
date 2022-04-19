namespace Cqrs.Queries;

public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery
{
    Task<TQueryResult> HandleAsync(TQuery query, CancellationToken cancellation = default);
}