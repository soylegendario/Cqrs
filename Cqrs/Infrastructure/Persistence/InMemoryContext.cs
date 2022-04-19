using Cqrs.Domain;

namespace Cqrs.Persistence;

public class InMemoryContext
{
    public InMemoryContext()
    {
        Products = new List<Product>();
        for (var i = 0; i < 10; i++)
        {
            Products.Add(new Product
            {
                Id = i,
                Name = $"Product {i}"
            });
        }
    }

    public IList<Product> Products { get; }
}