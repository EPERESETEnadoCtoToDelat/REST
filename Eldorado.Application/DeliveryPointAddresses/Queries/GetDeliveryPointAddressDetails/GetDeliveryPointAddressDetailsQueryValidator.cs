using FluentValidation;

namespace Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressDetails;

public class GetDeliveryPointAddressDetailsQueryValidator : AbstractValidator<GetDeliveryPointAddressDetailsQuery>
{
    public GetDeliveryPointAddressDetailsQueryValidator()
    {
        RuleFor(getDeliveryPointAddressDetailsQuery => 
            getDeliveryPointAddressDetailsQuery.Id).NotNull().NotEqual(Guid.Empty);
    }
}