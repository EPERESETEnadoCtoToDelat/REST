using FluentValidation;

namespace Eldorado.Application.DeliveryPointAddresses.Commands.UpdateDeliveryPointAddress;

public class UpdateDeliveryPointAddressCommandValidator : AbstractValidator<UpdateDeliveryPointAddressCommand>
{
    public UpdateDeliveryPointAddressCommandValidator()
    {
        RuleFor(updateDeliveryPointAddressesCommand =>
            updateDeliveryPointAddressesCommand.Id).NotEqual(Guid.Empty).NotNull();
        RuleFor(updateDeliveryPointAddressesCommand => 
            updateDeliveryPointAddressesCommand.City).NotEmpty().NotNull();
        RuleFor(updateDeliveryPointAddressesCommand => 
            updateDeliveryPointAddressesCommand.House).NotEmpty().NotNull();
        RuleFor(updateDeliveryPointAddressesCommand =>
            updateDeliveryPointAddressesCommand.Street).NotEmpty().NotNull();
    }
}