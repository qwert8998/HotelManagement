using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;

namespace TzuChing.HotelManagement.ApplicationCore.RepositoryInterface
{
    public interface IRoomTypeRepository : IAsyncRepository<RoomTypes>
    {
        Task<RoomTypes> GetByName(string name);
        Task UpdateRoomType(RoomTypeRequest request);
    }
}
