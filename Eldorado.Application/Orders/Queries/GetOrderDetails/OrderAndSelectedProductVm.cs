namespace Eldorado.Application.Orders.Queries.GetOrderDetails;

public class OrderAndSelectedProductVm
{
    public OrderDetailsVm OrderDetails { get; set; } = null!;

    public IList<SelectedProductQueryDto> SelectedProducts { get; set; } = null!;
}