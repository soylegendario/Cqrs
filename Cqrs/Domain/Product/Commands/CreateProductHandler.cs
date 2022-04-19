using Cqrs.Commands;

namespace Cqrs.Domain.Commands;

public class CreateProductHandler : ICommandHandler<CreateProduct>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository repository)
    {
        _productRepository = repository;
    }

    public Task HandleAsync(CreateProduct command, CancellationToken cancellation = default)
    {
        var product = new Product { Name = command.Name };
        return _productRepository.AddProductAsync(product);
    }
}