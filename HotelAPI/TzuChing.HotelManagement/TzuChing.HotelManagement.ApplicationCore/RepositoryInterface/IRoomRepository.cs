using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;

namespace TzuChing.HotelManagement.ApplicationCore.RepositoryInterface
{
    public interface IRoomRepository : IAsyncRepository<Rooms>
    {
        Task UpdateRoome(RoomRequest request);
    }
}
