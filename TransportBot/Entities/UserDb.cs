using TransportBot.Helpers;

namespace TransportBot.Entities
{
    public class UserDb
    {
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? Name { get; set; }
        public string TelegramNick { get; set; }
        public DateOnly? BirthDate { get; set; }
        public DateOnly? LastTrip { get; set; }
        public decimal? Discount { get; set; }
        public SubscriptionType? SubscriptionType { get; set; }
        public bool? IsSubscriptionActive { get; set; }
        public int? SubscriptionTripsCount { get; set; }
        public int TripsCount { get; set; }
        public string PhoneNumber { get; set; }
        public IList<AddressDb> Addresses { get; set; }
        public string? Note { get; set; }
    }
}