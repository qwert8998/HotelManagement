using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TzuChing.HotelManagement.ApplicationCore.Models.Request
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public decimal? Amount { get; set; }
        public string SDESC { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
}
