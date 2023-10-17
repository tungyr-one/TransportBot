using System.ComponentModel.DataAnnotations;

namespace TransportBot.Entities
{
    public class OrderEntity
    {
        [Key]
        public int OrderId { get; set; }
        public int TripId { get; set; }
        public TripEntity Trip { get; set; }  =  new TripEntity();
        public int UserId { get; set; }
        public UserEntity User { get; set; } = new UserEntity();
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int PassengersNumber { get; set; }
        public int? ChildrenNumber { get; set; }
        public decimal OrderPrice { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }
        public string? UserNotes { get; set; }
    }
}