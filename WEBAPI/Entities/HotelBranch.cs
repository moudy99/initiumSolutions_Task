namespace WEBAPI.Entities
{
    public class HotelBranch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
