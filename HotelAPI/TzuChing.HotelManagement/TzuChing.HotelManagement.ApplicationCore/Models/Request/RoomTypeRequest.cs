namespace TzuChing.HotelManagement.ApplicationCore.Models.Request
{
    public class RoomTypeRequest
    {
        public int Id { get; set; }
        public string RTDESC { get; set; }
        public decimal? Rent { get; set; }
    }
}
