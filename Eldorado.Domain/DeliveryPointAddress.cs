namespace Eldorado.Domain
{
    public class DeliveryPointAddress
    {
        public Guid Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? House { get; set; }
        public Guid DeliveryPointId { get; set; }
        public DeliveryPoint? DeliveryPoint { get; set; }
    }
}