using ConsumeAPI.ViewModel;

namespace ConsumeAPI.Repository
{
    public interface IHotelRepository
    {
        Task<List<HotelViewModel>> GetBranchNamesAsync();
        Task<customResponse<string>> BookRoomAsync(BookingViewModel bookingRequest);
    }
}
