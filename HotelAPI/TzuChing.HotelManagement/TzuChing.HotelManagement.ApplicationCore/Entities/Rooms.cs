using System.Collections.Generic;

namespace TzuChing.HotelManagement.ApplicationCore.Entities
{
    public class Rooms
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public bool? Status { get; set; }
        public RoomTypes RoomType { get; set; }
        public ICollection<Services> Service { get; set; }
        public ICollection<Customers> Customer { get; set; }
    }
}
