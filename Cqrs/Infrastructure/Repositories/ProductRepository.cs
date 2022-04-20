using Cqrs.Domain;
using Cqrs.Persistence;

namespace Cqrs.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly InMemoryContext _context;

    public ProductRepository(InMemoryContext context)
    {
        _context = context;
    }

    public Task AddProductAsync(Product product)
    {
        return Task.Run(() =>
        {
            var id = _context.Products.Max(p => p.Id) + 1;
            product.Id = id;
            _context.Products.Add(product);
        });
    }

    public Task<IEnumerable<Product>> GetProductsAsync(int fromId, int toId)
    {
        return Task.FromResult(_context.Products.Where(p => p.Id >= fromId && p.Id <= toId));
    }
}