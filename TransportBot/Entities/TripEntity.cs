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
        public int PassangersNumber { get; set; }
        public int? ChildrenNumber { get; set; }
        public decimal TripProfit { get; set; }
    }
}