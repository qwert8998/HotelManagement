using System;

namespace TzuChing.HotelManagement.ApplicationCore.Entities
{
    public class Services
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string SDESC { get; set; }
        public DateTime? ServiceDate { get; set; }
        public Rooms Room { get; set; }
    }
}
