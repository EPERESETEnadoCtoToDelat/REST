using System.Data;
using FluentValidation;

namespace Eldorado.Application.DeliveryPoints.Commands.DeleteDeliveryPoint;

public class DeleteDeliveryPointCommandValidator : AbstractValidator<DeleteDeliveryPointCommand>
{
    public DeleteDeliveryPointCommandValidator()
    {
        RuleFor(deleteDeliveryPointCommand => 
            deleteDeliveryPointCommand.Id).NotNull().NotEqual(Guid.Empty);
    }
}