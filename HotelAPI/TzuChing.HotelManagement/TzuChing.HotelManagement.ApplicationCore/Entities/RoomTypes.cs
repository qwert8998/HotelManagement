using System.Collections.Generic;

namespace TzuChing.HotelManagement.ApplicationCore.Entities
{
    public class RoomTypes
    {
        public int Id { get; set; }
        public string RTDESC { get; set; }
        public decimal? Rent { get; set; }
        public ICollection<Rooms> Room { get; set; }
    }
}
