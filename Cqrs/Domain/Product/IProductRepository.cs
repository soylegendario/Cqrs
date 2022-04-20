namespace Cqrs.Domain;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task<IEnumerable<Product>> GetProductsAsync(int fromId, int toId);
}