using ConsumeAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace ConsumeAPI.ViewModel
{
    public class RoomViewModel
    {
        [Required(ErrorMessage = "Room type is required")]
        [Display(Name = "Room Type")]
        public RoomTypeEnum Type { get; set; }

        [Required(ErrorMessage = "Number of adults is required")]
        [Display(Name = "Number of Adults")]
        public int NumberOfAdults { get; set; }

        [Required(ErrorMessage = "Number of children is required")]
        [Display(Name = "Number of Children")]
        public int NumberOfChildren { get; set; }
    }
}
