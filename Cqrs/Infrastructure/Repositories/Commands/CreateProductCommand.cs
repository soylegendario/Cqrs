using Cqrs.Commands;

namespace Cqrs.Repositories.Commands;

public class CreateProductCommand : ICommand
{
    public string Name { get; set; }
}