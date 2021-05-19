using System.Collections.Generic;
using TzuChing.HotelManagement.ApplicationCore.Entities;

namespace TzuChing.HotelManagement.ApplicationCore.Models.Response
{
    public class RoomResponse : BasicResponse
    {
        public RoomModel Room { get; set; }
    }

    public class RoomModel
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public bool? Status { get; set; }
    }

    public class ListAllRoomsResponse : BasicResponse
    {
        public IEnumerable<RoomModel> RoomList { get; set; }
    }
}
