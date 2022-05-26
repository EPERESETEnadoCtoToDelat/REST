using FluentValidation;

namespace Eldorado.Application.DeliveryPointAddresses.Commands.CreateDeliveryPointAddress;

public class CreateDeliveryPointAddressesCommandValidator : AbstractValidator<CreateDeliveryPointAddressesCommand>
{
    public CreateDeliveryPointAddressesCommandValidator()
    {
        RuleFor(createDeliveryPointAddressesCommand => 
            createDeliveryPointAddressesCommand.City).NotEmpty().NotNull();
        RuleFor(createDeliveryPointAddressesCommand => 
            createDeliveryPointAddressesCommand.House).NotEmpty().NotNull();
        RuleFor(createDeliveryPointAddressesCommand =>
            createDeliveryPointAddressesCommand.Street).NotEmpty().NotNull();
    }
}