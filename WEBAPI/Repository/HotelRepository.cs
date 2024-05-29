using Microsoft.EntityFrameworkCore;
using WEBAPI.Entities;
using WEBAPI.Interfaces;

namespace WEBAPI.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HotelBranch>> GetBranchNamesAsync()
        {
            return await _context.HotelBranches.ToListAsync();
        }

        public async Task AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByNationalIDAsync(string nationalID)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.NationalID == nationalID);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasPreviousBookingAsync(string nationalID)
        {
            return await _context.Bookings.AnyAsync(b => b.Customer.NationalID == nationalID);
        }
    }
}
