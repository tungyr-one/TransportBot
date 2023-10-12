namespace TransportBot.Entities
{
    public class AddressDb
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        public string? GeoLink { get; set; }
        public int UserId { get; set; }
        public UserDb User { get; set; }
    }
}