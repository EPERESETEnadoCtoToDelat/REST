using FluentValidation;

namespace Eldorado.Application.DeliveryPoints.Commands.UpdateDeliveryPoint;

public class UpdateDeliveryPointCommandValidator : AbstractValidator<UpdateDeliveryPointCommand>
{
    public UpdateDeliveryPointCommandValidator()
    {
        RuleFor(updateDeliveryPointCommand =>
            updateDeliveryPointCommand.Id).NotNull().NotEqual(Guid.Empty);
        RuleFor(updateDeliveryPointCommand => 
            updateDeliveryPointCommand.WorkingTime).NotNull();
        RuleFor(updateDeliveryPointCommand =>
            updateDeliveryPointCommand.DeliveryPointAddressCommand).NotNull();
    }
}