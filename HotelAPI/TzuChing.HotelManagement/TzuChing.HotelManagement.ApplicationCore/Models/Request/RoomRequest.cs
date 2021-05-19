namespace TzuChing.HotelManagement.ApplicationCore.Models.Request
{
    public class RoomRequest
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public bool? Status { get; set; }
    }
}
