using FluentValidation;

namespace Eldorado.Application.DeliveryPoints.Queries.GetDeliveryPointDetails;

public class GetDeliveryPointDetailsQueryValidator : AbstractValidator<GetDeliveryPointDetailsQuery>
{
    public GetDeliveryPointDetailsQueryValidator()
    {
        RuleFor(getDeliveryPointDetailsQuery =>
            getDeliveryPointDetailsQuery.Id).NotNull().NotEqual(Guid.Empty);
    }
}