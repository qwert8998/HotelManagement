using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;
using TzuChing.HotelManagement.ApplicationCore.ServiceInterface;

namespace TzuChing.HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost("AddRoom")]
        public async Task<IActionResult> AddRoom(RoomRequest request)
        {
            var result = await _roomService.AddRoom(request);
            return Ok(result);
        }

        [HttpPost("UpdateRoom")]
        public async Task<IActionResult> UpdateRoom(RoomRequest request)
        {
            var result = await _roomService.UpdateRoom(request);
            return Ok(result);
        }

        [HttpPost("RemoveRoom")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var result = await _roomService.RemoveRoom(id);
            return Ok(result);
        }

        [HttpGet("ListRooms")]
        public async Task<IActionResult> ListAllRooms()
        {
            var result = await _roomService.GetAllRooms();
            return Ok(result);
        }
    }
}
