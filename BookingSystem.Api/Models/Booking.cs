using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PassengerName { get; set; } = "";
        public string PassportNo { get; set; } = "";
        public string Destination { get; set; } = "";
        public bool IsOnTime { get; set; } = true;
    }
}