using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;
using TzuChing.HotelManagement.ApplicationCore.Models.Response;
using TzuChing.HotelManagement.ApplicationCore.RepositoryInterface;
using TzuChing.HotelManagement.ApplicationCore.ServiceInterface;

namespace TzuChing.HotelManagement.Infrastructure.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository
            , IRoomRepository roomRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> AddService (ServiceRequest request)
        {
            var add = _mapper.Map<Services>(request);
            if(request.RoomId != null)
            {
                var room = await _roomRepository.GetByIdAsync(request.RoomId.Value);
                if (room == null)
                    return new ServiceResponse() { Message = "Room is not existed!" };
            }
            var added = await _serviceRepository.AddAsync(add);
            if (added == null)
                return new ServiceResponse() { Message = "Add failed!" };
            var response = MapServiceResponse(added);
            response.Message = "Success";
            return response;
        }

        public async Task<ServiceResponse> UpdateService (ServiceRequest request)
        {
            var update = _mapper.Map<Services>(request);
            if (request.RoomId != null)
            {
                var room = await _roomRepository.GetByIdAsync(request.RoomId.Value);
                if (room == null)
                    return new ServiceResponse() { Message = "Room is not existed!" };
            }
            await _serviceRepository.UpdateService(update);
            var response = MapServiceResponse(update);
            response.Message = "Success";
            return response;
        }

        public async Task<BasicResponse> DeleteService (int id)
        {
            var ser = await _serviceRepository.GetByIdAsync(id);
            await _serviceRepository.DeleteAsync(ser);
            return new BasicResponse() { Message = "Success" };
        }

        public async Task<ListServicesResponse> GetAllService()
        {
            var sers = await _serviceRepository.ListAllAsync();
            var list = new List<ServiceModel>();
            foreach(var item in sers)
            {
                list.Add(new ServiceModel { 
                    Id = item.Id,
                    RoomId = item.RoomId,
                    SDESC = item.SDESC,
                    ServiceDate = item.ServiceDate,
                    Amount = item.Amount
                }) ;
            }

            return new ListServicesResponse() { 
                List = list,
                Message = "Success"
            };
        }

        public async Task<ServiceResponse> GetServiceById(int id)
        {
            var ser = await _serviceRepository.GetByIdAsync(id);
            var response = MapServiceResponse(ser);
            response.Message = "Success";
            return response;
        }

        public async Task<ServiceModel> GetServiceByRoomAndDate (int room, DateTime date)
        {
            var ser = await _serviceRepository.GetServicesByRoomAndDate(room, date);
            var result = _mapper.Map<ServiceModel>(ser);
            return result;
        }

        private ServiceResponse MapServiceResponse (Services services)
        {
            var ser = new ServiceModel() { 
                    Id = services.Id,
                    RoomId = services.RoomId,
                    SDESC = services.SDESC,
                    ServiceDate = services.ServiceDate,
                    Amount = services.Amount
            };
            return new ServiceResponse() { Service = ser };
        }
    }
}
