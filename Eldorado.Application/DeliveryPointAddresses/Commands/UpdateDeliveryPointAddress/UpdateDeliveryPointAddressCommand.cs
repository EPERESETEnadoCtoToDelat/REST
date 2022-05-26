using MediatR;

namespace Eldorado.Application.DeliveryPointAddresses.Commands.UpdateDeliveryPointAddress;

public class UpdateDeliveryPointAddressCommand : IRequest
{
    public Guid Id { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? House { get; set; }
}