using AutoMapper;
using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.ProductCatigories.Queries.GetProductCategoryDetails;

public class GetProductCategoryDetailsQueryHandler : IRequestHandler<GetProductCategoryDetailsQuery, ProductCategoryDetailsVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProductCategoryDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<ProductCategoryDetailsVm> Handle(GetProductCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.ProductCategories
            .FirstOrDefaultAsync(productCategory =>
                productCategory.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(ProductCategory), request.Id);

        return _mapper.Map<ProductCategoryDetailsVm>(entity);
    }
}