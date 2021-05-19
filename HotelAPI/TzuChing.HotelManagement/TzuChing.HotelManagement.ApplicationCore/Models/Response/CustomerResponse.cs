using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TzuChing.HotelManagement.ApplicationCore.Models.Response
{
    public class CustomerResponse : BasicResponse
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string CName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CheckIn { get; set; }
        public int? TotalPersons { get; set; }
        public int? BookingDays { get; set; }
        public decimal? Advance { get; set; }
    }

    public class ListAllCustomer : BasicResponse
    {
        public List<CustomerModel> CustomerList { get; set; }
    }

    public class CustomerModel
    {
        public int Id { get; set; }
        public string CName { get; set; }
    }
}
