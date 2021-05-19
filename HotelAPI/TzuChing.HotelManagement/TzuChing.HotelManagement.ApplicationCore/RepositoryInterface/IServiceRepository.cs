using System;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;

namespace TzuChing.HotelManagement.ApplicationCore.RepositoryInterface
{
    public interface IServiceRepository : IAsyncRepository<Services>
    {
        Task<Services> GetServicesByRoomAndDate(int roomId, DateTime date);
        Task UpdateService(Services ser);
    }
}
