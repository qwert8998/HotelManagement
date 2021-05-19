using AutoMapper;
using TzuChing.HotelManagement.ApplicationCore.Entities;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;
using TzuChing.HotelManagement.ApplicationCore.Models.Response;

namespace TzuChing.HotelManagement.Infrastructure.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomTypeRequest, RoomTypes>();
            CreateMap<RoomRequest, Rooms>();
            CreateMap<CustomerRequest, Customers>();
            CreateMap<Customers,CustomerResponse>();
            CreateMap<Rooms, RoomRequest>();
            CreateMap<ServiceRequest, Services>();
            CreateMap<Services,ServiceModel>();
            CreateMap<Services, ServiceResponse>()
                .ForMember(p => p.Service, opt => opt.MapFrom(src => src));
        }
    }
}
