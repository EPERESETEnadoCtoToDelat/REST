namespace Eldorado.Domain
{
    public class DeliveryPoint
    {
        public Guid Id { get; set; }
        public DeliveryPointAddress DeliveryPointAddress { get; set; } = new DeliveryPointAddress();
        public DateTime WorkingTime { get; set; }
        public List<Order>? Orders { get; set; }
    }
}