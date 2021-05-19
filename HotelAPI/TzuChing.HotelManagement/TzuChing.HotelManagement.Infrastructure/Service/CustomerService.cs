using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;
using TzuChing.HotelManagement.ApplicationCore.Models.Response;
using TzuChing.HotelManagement.ApplicationCore.RepositoryInterface;
using TzuChing.HotelManagement.ApplicationCore.ServiceInterface;

namespace TzuChing.HotelManagement.Infrastructure.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IServiceService _serviceService;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository
            , IRoomRepository roomRepository, IServiceService serviceService, IMapper mapper
            ,IRoomTypeRepository roomTypeRepository)
        {
            _customerRepository = customerRepository;
            _roomRepository = roomRepository;
            _serviceService = serviceService;
            _roomTypeRepository = roomTypeRepository;
            _mapper = mapper;
        }

        public async Task<CustomerResponse> AddCustomer (CustomerRequest request)
        {
            if(request.RoomId != null)
            {
                var room = await _roomRepository.GetByIdAsync(request.RoomId.Value);
                if(room != null)
                {
                    if (room.Status.Value)
                    {
                        room.Status = false;
                        await _roomRepository.UpdateAsync(room);
                        var type =  await _roomTypeRepository.GetByIdAsync(room.RoomTypeId);
                        await AddService(request, type.Rent);
                    }
                    else
                    {
                        var cuss = await _customerRepository.GetAllCustomerByRoomId(room.Id);
                        
                        if(!CheckRoomStatus(cuss, request.CheckIn.Value, request.BookingDays.Value))
                            return new CustomerResponse() { Message = "Room has been booked!" };
                        else
                        {
                            var type = await _roomTypeRepository.GetByIdAsync(room.RoomTypeId);
                            await AddService(request, type.Rent);
                        }
                    }
                        
                }
                else
                {
                    return new CustomerResponse() { Message = "Room is not existed!" };
                }
            }
            var cus = _mapper.Map<Customers>(request);
            var added = await _customerRepository.AddAsync(cus);
            var response = _mapper.Map<CustomerResponse>(added);
            response.Message = "Success";
            return response;
        }

        public async Task<CustomerResponse> UpdateCustomer (CustomerRequest request)
        {
            if (!await UpdateRoom(request))
                return new CustomerResponse() { Message = "Room has been booked!" };

            var update = _mapper.Map<Customers>(request);
            await _customerRepository.UpdateCustomer(update);
            var response = _mapper.Map<CustomerResponse>(update);
            response.Message = "Success";
            return response;
        }

        public async Task<BasicResponse> DeleteCustomer (int id)
        {
            var cus = await _customerRepository.GetByIdAsync(id);
            if (cus.RoomId != null)
                await CanceledRoom(cus.RoomId.Value, id);
            await _customerRepository.DeleteAsync(cus);
            return new BasicResponse() { Message = "Success" };
        }

        public async Task<ListAllCustomer> GetAllCustomers ()
        {
            var result = await _customerRepository.ListAllAsync();
            var list = new List<CustomerModel>();
            foreach (var item in result)
            {
                list.Add(new CustomerModel(){ 
                    CName = item.CName,
                    Id = item.Id
                });
            }
            return new ListAllCustomer() { 
                CustomerList = list,
                Message = "Success"
            };
        }

        public async Task<CustomerResponse> GetCustomerById (int id)
        {
            var result = await _customerRepository.GetByIdAsync(id);
            var response = _mapper.Map<CustomerResponse>(result);
            response.Message = "Success";
            return response;
        }

        private async Task AddService(CustomerRequest request, decimal? rent)
        {
            var amount = rent ?? 0 + request.Advance ?? 0;
            var servicereq = new ServiceRequest()
            {
                RoomId = request.RoomId,
                SDESC = $"{request.CName} book room with advanced {request.Advance ?? 0}",
                Amount = amount,
                ServiceDate = request.CheckIn
            };

            await _serviceService.AddService(servicereq);
        }

        private async Task UpdateService(CustomerRequest request, int oldroom, DateTime oldtime, decimal? rent)
        {
            var ser = await _serviceService.GetServiceByRoomAndDate(oldroom,oldtime);
            if (ser != null)
            {
                var amount = rent ?? 0 + request.Advance ?? 0;
                var servicereq = new ServiceRequest()
                {
                    Id = ser.Id,
                    RoomId = request.RoomId,
                    SDESC = $"{request.CName} book room with advanced {request.Advance ?? 0}",
                    Amount = amount,
                    ServiceDate = request.CheckIn
                };

                await _serviceService.UpdateService(servicereq);
            }
            else
                await AddService(request, rent);
        }

        private async Task<bool> UpdateRoom (CustomerRequest request)
        {
            var old = await _customerRepository.GetByIdAsync(request.Id);
            if (old.RoomId != null)
            {
                if (request.RoomId == null)
                {
                    await CanceledRoom(old.RoomId.Value, old.Id);
                }
                else if (request.RoomId.Value != old.RoomId.Value)
                {
                    var room = await _roomRepository.GetByIdAsync(request.RoomId.Value);
                    if (room.Status.Value)
                    {
                        await CanceledRoom(old.RoomId.Value, old.Id);
                        await BookRoom(request.RoomId.Value);
                    }
                    else
                    {
                        var cuss = await _customerRepository.GetAllCustomerByRoomId(room.Id);

                        if (!CheckRoomStatus(cuss, request.CheckIn.Value, request.BookingDays.Value))
                            return false;
                    }
                    var type = await _roomTypeRepository.GetByIdAsync(room.RoomTypeId);
                    await UpdateService(request, old.RoomId.Value, old.CheckIn.Value, type.Rent);
                }
            }
            else
            {
                if (request.RoomId != null)
                {
                    var room = await _roomRepository.GetByIdAsync(request.RoomId.Value);
                    if (room.Status.Value)
                        await BookRoom(room.Id);
                    else
                    {
                        var cuss = await _customerRepository.GetAllCustomerByRoomId(room.Id);

                        if (!CheckRoomStatus(cuss, request.CheckIn.Value, request.BookingDays.Value))
                            return false;
                    }
                    var type = await _roomTypeRepository.GetByIdAsync(room.RoomTypeId);
                    await AddService(request, type.Rent);
                }
            }
            return true;
        }

        private bool CheckRoomStatus(List<Customers> customers, DateTime date, int days)
        {
            foreach(var item in customers)
            {
                if(item.CheckIn != null && item.BookingDays != null)
                {
                    if ((date > item.CheckIn.Value && date < item.CheckIn.Value.AddDays(item.BookingDays.Value)) ||
                        (date.AddDays(days) > item.CheckIn.Value && date < item.CheckIn.Value) ||
                        (date < item.CheckIn.Value.AddDays(item.BookingDays.Value) && date.AddDays(days) > item.CheckIn.Value.AddDays(item.BookingDays.Value)))
                        return false;
                }
            }
            return true;
        }

        private async Task BookRoom(int roomId)
        {
            var room = await _roomRepository.GetByIdAsync(roomId);
            room.Status = false;
            var update = _mapper.Map<RoomRequest>(room);
            await _roomRepository.UpdateRoome(update);
        }

        private async Task CanceledRoom (int roomId, int cusId)
        {
            var cus = await _customerRepository.GetAllCustomerByRoomId(roomId);
            if(cus.Count == 1 && cus[0].Id == cusId)
            {
                var room = await _roomRepository.GetByIdAsync(roomId);
                room.Status = true;
                var update = _mapper.Map<RoomRequest>(room);
                await _roomRepository.UpdateRoome(update);
            }
        }
    }
}
