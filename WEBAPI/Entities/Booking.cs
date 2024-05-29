namespace WEBAPI.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int BranchID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool DiscountApplied { get; set; }

        public Customer? Customer { get; set; }
        public ICollection<BookingRoom> BookingRooms { get; set; }
    }
}
