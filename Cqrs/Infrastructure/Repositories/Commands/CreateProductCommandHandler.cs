using Cqrs.Commands;
using Cqrs.Domain;

namespace Cqrs.Repositories.Commands;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _productRepository = repository;
    }

    public Task HandleAsync(CreateProductCommand command, CancellationToken cancellation = default)
    {
        var product = new Product { Name = command.Name };
        return _productRepository.AddProductAsync(product);
    }
}