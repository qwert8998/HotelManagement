using AutoMapper;
using TzuChing.HotelManagement.ApplicationCore.Entities;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;

namespace TzuChing.HotelManagement.Infrastructure.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomTypeRequest, RoomTypes>();
            CreateMap<RoomRequest, Rooms>();
        }
    }
}
