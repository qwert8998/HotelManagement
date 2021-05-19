using System;

namespace TzuChing.HotelManagement.ApplicationCore.Entities
{
    public class Customers
    {
        public int Id { get; set; }
        public int? RoomId { get; set; } 
        public string CName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CheckIn { get; set; }
        public int? TotalPersons { get; set; }
        public int? BookingDays { get; set; }
        public decimal? Advance { get; set; }
        public Rooms Room { get; set; }
    }
}
