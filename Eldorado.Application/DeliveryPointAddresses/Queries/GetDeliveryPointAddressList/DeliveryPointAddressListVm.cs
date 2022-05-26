using MediatR;

namespace Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressList;

public class DeliveryPointAddressListVm
{
    public IList<DeliveryPointAddressLookupDto>? DeliveryPointAddresses { get; set; }
}