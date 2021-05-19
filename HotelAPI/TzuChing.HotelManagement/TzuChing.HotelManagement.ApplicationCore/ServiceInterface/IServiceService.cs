using System;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;
using TzuChing.HotelManagement.ApplicationCore.Models.Response;

namespace TzuChing.HotelManagement.ApplicationCore.ServiceInterface
{
    public interface IServiceService
    {
        Task<ServiceResponse> AddService(ServiceRequest request);
        Task<ServiceResponse> UpdateService(ServiceRequest request);
        Task<BasicResponse> DeleteService(int id);
        Task<ListServicesResponse> GetAllService();
        Task<ServiceResponse> GetServiceById(int id);
        Task<ServiceModel> GetServiceByRoomAndDate(int room, DateTime date);
    }
}
