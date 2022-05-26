using MediatR;

namespace Eldorado.Application.DeliveryPoints.Queries.GetDeliveryPointDetails;

public class GetDeliveryPointDetailsQuery : IRequest<DeliveryPointDetailsVm>
{
    public Guid Id { get; set; }
}