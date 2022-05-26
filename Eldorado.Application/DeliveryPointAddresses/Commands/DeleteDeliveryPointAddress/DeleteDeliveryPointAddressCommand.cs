using MediatR;

namespace Eldorado.Application.DeliveryPointAddresses.Commands.DeleteDeliveryPointAddress;

public class DeleteDeliveryPointAddressCommand : IRequest
{
    public Guid Id;
}