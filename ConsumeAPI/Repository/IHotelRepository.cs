using ConsumeAPI.ViewModel;

namespace ConsumeAPI.Repository
{
    public interface IHotelRepository
    {
        Task<List<HotelViewModel>> GetBranchNamesAsync();
        Task<string> BookRoomAsync(BookingViewModel bookingRequest);
    }
}
