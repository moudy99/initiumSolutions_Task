using WEBAPI.Enums;

namespace WEBAPI.DTOs
{
    public class RoomDto
    {
        public RoomTypeEnum Type { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }

    }
}
