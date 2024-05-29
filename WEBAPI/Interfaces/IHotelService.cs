using WEBAPI.DTOs;

namespace WEBAPI.Interfaces
{
    public interface IHotelService
    {
        Task<CustomResponseDTO<List<BranchDto>>> GetBranchNamesAsync();
        Task<CustomResponseDTO<string>> BookRoomAsync(BookingRequestDto bookingRequest);


    }
}
