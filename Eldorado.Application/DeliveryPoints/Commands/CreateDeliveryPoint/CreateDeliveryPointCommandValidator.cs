using System.Data;
using FluentValidation;

namespace Eldorado.Application.DeliveryPoints.Commands.CreateDeliveryPoint;

public class CreateDeliveryPointCommandValidator : AbstractValidator<CreateDeliveryPointCommand>
{
    public CreateDeliveryPointCommandValidator()
    {
        RuleFor(createDeliveryPointCommand => createDeliveryPointCommand.WorkingTime).NotNull();
        RuleFor(createDeliveryPointCommand => createDeliveryPointCommand.DeliveryPointAddress).NotNull();
    }
}