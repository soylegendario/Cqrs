using Cqrs.Queries;

namespace Cqrs.Domain.Queries;

public class GetProductsHandler : IQueryHandler<GetProducts, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsHandler(IProductRepository repository)
    {
        _productRepository = repository;
    }

    public Task<IEnumerable<Product>> HandleAsync(GetProducts query, CancellationToken cancellation = default)
    {
        return _productRepository.GetProductsAsync(query.FromId, query.ToId);
    }
}