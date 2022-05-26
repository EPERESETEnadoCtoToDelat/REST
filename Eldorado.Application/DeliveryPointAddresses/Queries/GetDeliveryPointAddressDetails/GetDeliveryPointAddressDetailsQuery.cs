using MediatR;

namespace Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressDetails;

public class GetDeliveryPointAddressDetailsQuery : IRequest<DeliveryPointAddressDetailsVm>
{
    public Guid Id { get; set; }
}