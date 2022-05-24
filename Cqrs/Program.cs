using Cqrs.Commands;
using Cqrs.Domain;
using Cqrs.Persistence;
using Cqrs.Queries;
using Cqrs.Repositories;
using Cqrs.Repositories.Commands;
using Cqrs.Repositories.Queries;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Persistence and Repositories
services.AddSingleton<InMemoryContext>();
services.AddScoped<IProductRepository, ProductRepository>();

// Commands/Queries dispatchers
services.AddScoped<ICommandDispatcher, CommandDispatcher>();
services.AddScoped<IQueryDispatcher, QueryDispatcher>();

// Commands/Queries handlers
services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
services.AddScoped<IQueryHandler<GetProductsQuery, IEnumerable<Product>>, GetProductsQueryHandler>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();