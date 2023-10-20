using System.ComponentModel.DataAnnotations;

namespace TransportBot.Entities
{
    public class TransportEntity
    {
        [Key]
        public int TransportId { get; set; }
        public string Name { get; set; }
        public string NumberPlate { get; set; }
        public int PassengersCapacity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastServiceDate { get; set; }
        public long? AverageFuelConsumption { get; set; }
        public int InitialMileage { get; set; }
        public int? CurrentMileage { get; set; }
    }
}