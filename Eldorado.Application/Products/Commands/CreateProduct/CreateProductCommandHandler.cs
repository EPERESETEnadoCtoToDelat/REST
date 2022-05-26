using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;

namespace Eldorado.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateProductCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Image = request.Image,
            Count = request.Count,
            Price = request.Price,
            Description = request.Description,
            Specifications = request.Specifications,
            Producer = request.Producer,
            ProductCategoryId = request.ProductCategoryId
        };

       await _dbContext.Products.AddAsync(product, cancellationToken);
       await _dbContext.SaveChangesAsync(cancellationToken);
       return product.Id;
    }
}