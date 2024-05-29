using System.ComponentModel.DataAnnotations;

namespace ConsumeAPI.ViewModel
{
    public class BookingViewModel
    {
        [Required(ErrorMessage = "Enter you Name")]
        public string CustomerName { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "The national id must be 14 number")]
        public string NationalID { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Select the Hotel ")]
        public int BranchID { get; set; }

        [Required(ErrorMessage = "Check-in date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check-out date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Compare(nameof(CheckInDate), ErrorMessage = "Check-out date must be after check-in date")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "You should book  at least one room")]
        public List<RoomViewModel> Rooms { get; set; }
    }
}
