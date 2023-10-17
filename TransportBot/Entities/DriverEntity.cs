using System.ComponentModel.DataAnnotations;

namespace TransportBot.Entities
{
    public class DriverEntity
    {
        [Key]
        public int DriverId { get; set; }
        public string Name { get; set; } = "John Doe";
        public string PhoneNumber { get; set; } = "+381 123456";
        public string TelegramNick { get; set; } = "@DefaultNick";
        public DateTime HiringDate { get; set; }
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = new AddressEntity();
        public decimal SalaryMonth { get; set; }
    }
}