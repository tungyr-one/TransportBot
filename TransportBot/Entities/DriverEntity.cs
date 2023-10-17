using System.ComponentModel.DataAnnotations;

namespace TransportBot.Entities
{
    public class DriverEntity
    {
        [Key]
        public int DriverId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TelegramNick { get; set; }
        public DateTime HiringDate { get; set; }
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }
        public decimal SalaryMonth { get; set; }
    }
}