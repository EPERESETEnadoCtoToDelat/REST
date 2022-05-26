using MediatR;

namespace Eldorado.Application.DeliveryPoints.Commands.CreateDeliveryPoint;

public class CreateDeliveryPointCommand : IRequest<Guid>
{
    public DateTime WorkingTime { get; set; }
    public DeliveryPointAddressCommandDto? DeliveryPointAddress { get; set; }
}

