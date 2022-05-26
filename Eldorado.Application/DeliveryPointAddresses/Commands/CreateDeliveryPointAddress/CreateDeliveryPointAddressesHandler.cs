using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;

namespace Eldorado.Application.DeliveryPointAddresses.Commands.CreateDeliveryPointAddress;

public class CreateDeliveryPointAddressesHandler : IRequestHandler<CreateDeliveryPointAddressesCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateDeliveryPointAddressesHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Guid> Handle(CreateDeliveryPointAddressesCommand request, CancellationToken cancellationToken)
    {
        var deliveryPointAddress = new DeliveryPointAddress
        {
            City = request.City,
            Street = request.Street,
            House = request.House,
            DeliveryPointId = request.DeliveryPointId
        };

        await _dbContext.DeliveryPointsAddress.AddAsync(deliveryPointAddress, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return deliveryPointAddress.Id;
    }
}