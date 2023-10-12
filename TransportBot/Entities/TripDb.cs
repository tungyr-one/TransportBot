namespace TransportBot.Entities
{
    public class TripDb
    {
        public int TripId { get; set; }
        public IList<OrderDb> Orders { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime TripDateTime { get; set; }
        public int PassangersNumber { get; set; }
        public int? ChildrenNumber { get; set; }
        public decimal TripPrice { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}