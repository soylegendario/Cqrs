using Cqrs.Commands;

namespace Cqrs.Domain.Commands;

public class CreateProduct : ICommand
{
    public string Name { get; set; }
}