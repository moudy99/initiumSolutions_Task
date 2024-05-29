using System.ComponentModel.DataAnnotations;

namespace WEBAPI.DTOs
{
    public class BookingRequestDto
    {
        [Required(ErrorMessage = "Enter you Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Enter your national ")]
        public string NationalID { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Select the Hotel ")]
        public int BranchID { get; set; }

        [Required(ErrorMessage = "Check-in date is required")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check-out date is required")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "You should book  at least one room")]
        public List<RoomDto> Rooms { get; set; }
    }
}