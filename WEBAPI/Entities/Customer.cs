namespace WEBAPI.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NationalID { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
