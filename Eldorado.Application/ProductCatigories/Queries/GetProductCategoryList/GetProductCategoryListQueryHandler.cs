using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.ProductCatigories.Queries.GetProductCategoryList;

public class GetProductCategoryListQueryHandler : IRequestHandler<GetProductCategoryListQuery, ProductCategoryListVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProductCategoryListQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<ProductCategoryListVm> Handle(GetProductCategoryListQuery request, CancellationToken cancellationToken)
    {
        var productCategoriesQuery = await _dbContext.ProductCategories
            .ProjectTo<ProductCategoryLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ProductCategoryListVm { ProductCategories = productCategoriesQuery };
    }
}