using Cqrs.Commands;

namespace Cqrs.Domain.Commands;

public class CreateProductCommand : ICommand
{
    public string Name { get; set; }
}