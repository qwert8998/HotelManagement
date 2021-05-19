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
    public class RoomService : IRoomService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomTypeRepository roomTypeRepository, IRoomRepository roomRepository
            , IMapper mapper)
        {
            _roomTypeRepository = roomTypeRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<RoomTypeResponse> AddRoomType (RoomTypeRequest request)
        {
            var room = _mapper.Map<RoomTypes>(request);
            var added = await _roomTypeRepository.AddAsync(room);
            return new RoomTypeResponse() {
                RoomType = added,
                Message = "Success"
            };
        }

        public async Task<RoomTypeResponse> UpdateRoomType (RoomTypeRequest request)
        {
            var room = await _roomTypeRepository.GetByIdAsync(request.Id);
            if (room == null)
            {
                return new RoomTypeResponse() { Message = $"{request.RTDESC} doesn't exist!" };
            }
            await _roomTypeRepository.UpdateRoomType(request);
            room = _mapper.Map<RoomTypes>(request);
            return new RoomTypeResponse() { 
                RoomType = room,
                Message = "Success"
            };
        }

        public async Task<ListAllRoomTypeResponse> GetAllRoomTypes ()
        {
            var result = await _roomTypeRepository.ListAllAsync();
            return new ListAllRoomTypeResponse() { 
                RoomTypeList = result,
                Message = "Success"
            };
        }

        public async Task<BasicResponse> RemoveRoomType (RoomTypeRequest request)
        {
            var room = await _roomTypeRepository.GetByIdAsync(request.Id);
            if (room == null)
                return new BasicResponse() { Message = $"{request.RTDESC} is not existed!" };
            await _roomTypeRepository.DeleteAsync(room);
            return new BasicResponse() { Message = "Success" };
        }

        public async Task<RoomResponse> AddRoom (RoomRequest request)
        {
            var room = _mapper.Map<Rooms>(request);
            var type = await _roomTypeRepository.GetByIdAsync(request.RoomTypeId);
            if (type == null)
                return new RoomResponse() { Message = $"RoomType {request.RoomTypeId} is not existed!" };
            var result = await _roomRepository.AddAsync(room);
            return new RoomResponse() { 
                Room = new RoomModel() { 
                    Id = result.Id,
                    RoomTypeId = result.RoomTypeId,
                    Status = result.Status
                },
                Message = "Success"
            };
        }

        public async Task<RoomResponse> UpdateRoom (RoomRequest request)
        {
            var room = await _roomRepository.GetByIdAsync(request.Id);
            if (room == null)
                return new RoomResponse() { Message = $"{request.Id} is not existed!" };
            await _roomRepository.UpdateRoome(request);
            room = _mapper.Map<Rooms>(request);
            return new RoomResponse() {
                Room = new RoomModel()
                {
                    Id = room.Id,
                    RoomTypeId = room.RoomTypeId,
                    Status = room.Status
                },
                Message = "Success"
            };
        }

        public async Task<BasicResponse> RemoveRoom (int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
                return new BasicResponse() {  Message = $"{id} is not existed!" };
            await _roomRepository.DeleteAsync(room);
            return new BasicResponse() { Message = "Success" };
        }

        public async Task<ListAllRoomsResponse> GetAllRooms ()
        {
            var result = await _roomRepository.ListAllAsync();
            return new ListAllRoomsResponse() { 
                RoomList = ConvertToModel(result),
                Message = "Success"
            };
        }

        private List<RoomModel> ConvertToModel (IEnumerable<Rooms> rooms)
        {
            var result = new List<RoomModel>();
            foreach (var item in rooms)
            {
                result.Add(new RoomModel() {
                    Id = item.Id,
                    RoomTypeId = item.RoomTypeId,
                    Status = item.Status
                });
            }

            return result;
        }
    }
}
