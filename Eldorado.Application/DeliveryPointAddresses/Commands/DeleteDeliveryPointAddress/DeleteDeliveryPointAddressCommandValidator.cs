using FluentValidation;

namespace Eldorado.Application.DeliveryPointAddresses.Commands.DeleteDeliveryPointAddress;

public class DeleteDeliveryPointAddressCommandValidator : AbstractValidator<DeleteDeliveryPointAddressCommand>
{
    public DeleteDeliveryPointAddressCommandValidator()
    {
        RuleFor(deleteDeliveryPointAddressCommand => 
            deleteDeliveryPointAddressCommand.Id).NotEqual(Guid.Empty);
    }
}