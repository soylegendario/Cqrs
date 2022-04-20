using Cqrs.Queries;

namespace Cqrs.Domain.Queries;

public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository repository)
    {
        _productRepository = repository;
    }

    public Task<IEnumerable<Product>> HandleAsync(GetProductsQuery query, CancellationToken cancellation = default)
    {
        return _productRepository.GetProductsAsync(query.FromId, query.ToId);
    }
}