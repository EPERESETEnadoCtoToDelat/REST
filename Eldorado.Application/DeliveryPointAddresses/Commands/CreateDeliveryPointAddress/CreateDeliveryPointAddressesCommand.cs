using MediatR;

namespace Eldorado.Application.DeliveryPointAddresses.Commands.CreateDeliveryPointAddress;

public class CreateDeliveryPointAddressesCommand : IRequest<Guid>
{
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? House { get; set; }
    public Guid DeliveryPointId { get; set; }
}