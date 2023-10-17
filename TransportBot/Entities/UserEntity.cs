using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace TransportBot.Entities
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? Name { get; set; }
        public string TelegramNick { get; set; } = "@DefaultNick";
        public DateTime? BirthDate { get; set; }
        public DateTime? LastTrip { get; set; }
        public string PhoneNumber { get; set; } = "+381 123456";
        public IList<AddressEntity> Addresses { get; set; } = new List<AddressEntity>();
        public int TripsCount { get; set; }

        public decimal? Discount { get; set; }
        public SubscriptionPeriod? SubscriptionType { get; set; }
        public bool? IsSubscriptionActive { get; set; }
        public int? SubscriptionTripsCount { get; set; }
        public string? Notes { get; set; }

        public IList<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}