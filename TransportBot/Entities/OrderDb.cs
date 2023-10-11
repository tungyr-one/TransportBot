using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using TransportBot.Helpers;

namespace TransportBot.Entities
{
    public class OrderDb
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public UserDb User { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime TripDateTime { get; set; }
        public int PassangersNumber { get; set; }
        public int? ChildrenNumber { get; set; }
        public decimal OrderPrice { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}