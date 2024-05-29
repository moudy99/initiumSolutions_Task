using WEBAPI.Entities;

namespace WEBAPI.Interfaces
{
    public interface IHotelRepository
    {
        Task<List<HotelBranch>> GetBranchNamesAsync();
        Task AddBookingAsync(Booking booking);
        Task<Customer> GetCustomerByNationalIDAsync(string nationalID);
        Task AddCustomerAsync(Customer customer);
        Task<bool> HasPreviousBookingAsync(string nationalID);
    }
}
