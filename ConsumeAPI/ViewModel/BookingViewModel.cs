using System.ComponentModel.DataAnnotations;

namespace ConsumeAPI.ViewModel
{
    public class BookingViewModel
    {
        [Required(ErrorMessage = "Enter your Name")]
        public string CustomerName { get; set; }

        public string NationalID { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Select the Hotel")]
        public int BranchID { get; set; }

        [Required(ErrorMessage = "Check-in date is required")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check-out date is required")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "You should book at least one room")]
        public List<RoomViewModel> Rooms { get; set; }
    }

    public class RoomViewModel
    {
        public string Type { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
    }
}