using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;

namespace TzuChing.HotelManagement.ApplicationCore.Models.Response
{
    public class RoomTypeResponse : BasicResponse
    {
        public RoomTypes RoomType { get; set; }
    }

    public class ListAllRoomTypeResponse : BasicResponse
    {
        public IEnumerable<RoomTypes> RoomTypeList { get; set; }
    }
}
