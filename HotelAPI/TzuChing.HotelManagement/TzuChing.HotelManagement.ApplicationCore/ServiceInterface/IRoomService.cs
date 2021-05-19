using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;
using TzuChing.HotelManagement.ApplicationCore.Models.Response;

namespace TzuChing.HotelManagement.ApplicationCore.ServiceInterface
{
    public interface IRoomService
    {
        Task<RoomTypeResponse> AddRoomType(RoomTypeRequest request);
        Task<RoomTypeResponse> UpdateRoomType(RoomTypeRequest request);
        Task<ListAllRoomTypeResponse> GetAllRoomTypes();
        Task<BasicResponse> RemoveRoomType(RoomTypeRequest request);
        Task<RoomResponse> AddRoom(RoomRequest request);
        Task<ListAllRoomsResponse> GetAllRooms();
        Task<BasicResponse> RemoveRoom(int id);
        Task<RoomResponse> UpdateRoom(RoomRequest request);
    }
}
