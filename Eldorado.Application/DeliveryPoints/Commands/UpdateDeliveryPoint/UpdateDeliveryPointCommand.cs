using MediatR;

namespace Eldorado.Application.DeliveryPoints.Commands.UpdateDeliveryPoint;

public class UpdateDeliveryPointCommand : IRequest
{
    public Guid Id { get; set; }
    public DateTime WorkingTime { get; set; }
    public DeliveryPointAddressCommandDto DeliveryPointAddressCommand { get; set; } = null!;
}