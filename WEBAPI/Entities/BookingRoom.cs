using WEBAPI.Enums;

namespace WEBAPI.Entities
{
    public class BookingRoom
    {
        public int ID { get; set; }
        public int BookingID { get; set; }
        public RoomTypeEnum Type { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }

        public Booking Booking { get; set; }
    }
}
