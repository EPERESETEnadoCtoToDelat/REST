using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eldorado.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.Products.Queries.GetProductList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var productsQuery = await _dbContext.Products
            .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ProductListVm { Products = productsQuery };
    }
}