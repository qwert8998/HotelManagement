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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost("AddService")]
        public async Task<IActionResult> AddService (ServiceRequest request)
        {
            var result = await _serviceService.AddService(request);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpPost("UpdateService")]
        public async Task<IActionResult> UpdateService(ServiceRequest request)
        {
            var result = await _serviceService.UpdateService(request);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpPost("DeleteService")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _serviceService.DeleteService(id);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            var result = await _serviceService.GetAllService();
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var result = await _serviceService.GetServiceById(id);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }
    }
}
