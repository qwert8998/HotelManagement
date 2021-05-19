using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TzuChing.HotelManagement.ApplicationCore.Models.Response
{
    public class ServiceResponse : BasicResponse
    {
        public ServiceModel Service { get; set; }
    }

    public class ListServicesResponse : BasicResponse
    {
        public List<ServiceModel> List { get; set; }
    }

    public class ServiceModel
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public decimal? Amount { get; set; }
        public string SDESC { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
}
