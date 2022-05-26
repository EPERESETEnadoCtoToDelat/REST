using MediatR;

namespace Eldorado.Application.DeliveryPoints.Commands.DeleteDeliveryPoint;

public class DeleteDeliveryPointCommand : IRequest
{
    public Guid Id { get; set; }
}