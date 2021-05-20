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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerRequest request)
        {
            var result = await _customerService.AddCustomer(request);
            return Ok(result);
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerRequest request)
        {
            var result = await _customerService.UpdateCustomer(request);
            return Ok(result);
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var result = await _customerService.GetAllCustomers();
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result.CustomerList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var result = await _customerService.GetCustomerById(id);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }
    }
}
