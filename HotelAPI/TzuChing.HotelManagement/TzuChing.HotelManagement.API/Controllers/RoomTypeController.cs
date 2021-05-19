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
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomTypeController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost("AddRoomType")]
        public async Task<IActionResult> AddRoomType(RoomTypeRequest request)
        {
            var result = await _roomService.AddRoomType(request);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpPost("DeleteRoomType")]
        public async Task<IActionResult> RemoveRoomType(int id)
        {
            var result = await _roomService.RemoveRoomType(id);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpPost("UpdateRoomType")]
        public async Task<IActionResult> UpdateRoomType(RoomTypeRequest request)
        {
            var result = await _roomService.UpdateRoomType(request);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpGet("GetAllRoomTypes")]
        public async Task<IActionResult> GetAllRoomTyps()
        {
            var result = await _roomService.GetAllRoomTypes();
            return Ok(result);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetTypeById (int id)
        {
            var result = await _roomService.GetRoomTypeById(id);
            if (result.Message != "Success")
                return NotFound(result);
            return Ok(result);
        }
    }
}
