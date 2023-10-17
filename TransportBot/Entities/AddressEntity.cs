using System.ComponentModel.DataAnnotations;

namespace TransportBot.Entities
{
    public class AddressEntity
    {
        [Key]
        public int AddressId { get; set; }
        public string City { get; set; } = "DefaultCity";
        public string Address { get; set; } = "DefaultAddress";
        public string? GeoLink { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; } = new UserEntity();
    }
}