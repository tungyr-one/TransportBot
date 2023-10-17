using System.ComponentModel.DataAnnotations;

namespace TransportBot.Entities
{
    public class TripEntity
    {
        [Key]
        public int TripId { get; set; }
        public IList<OrderEntity>? Orders { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime TripDateTime { get; set; }
        public int PassengersNumber { get; set; }
        public decimal TripProfit { get; set; }

        public int DriverId { get; set; }
        public DriverEntity Driver { get; set; } = new DriverEntity();
        public int TransportId { get; set; }
        public TransportEntity Transport { get; set; } = new TransportEntity();

    }
}