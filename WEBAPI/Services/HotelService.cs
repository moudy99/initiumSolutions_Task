using AutoMapper;
using WEBAPI.DTOs;
using WEBAPI.Entities;
using WEBAPI.Interfaces;

namespace WEBAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<List<BranchDto>>> GetBranchNamesAsync()
        {
            try
            {
                var branches = await _hotelRepository.GetBranchNamesAsync();
                var response = _mapper.Map<List<BranchDto>>(branches);
                return new CustomResponseDTO<List<BranchDto>>
                {
                    Data = response,
                    Message = "Branches retrieved successfully.",
                    Succeeded = true,
                    Errors = null,
                    DiscountApplied = false
                };
            }
            catch (Exception ex)
            {
                return new CustomResponseDTO<List<BranchDto>>
                {
                    Data = null,
                    Message = "An error occurred while retrieving branches.",
                    Succeeded = false,
                    Errors = new List<string> { ex.Message },
                    DiscountApplied = false
                };
            }
        }

        public async Task<CustomResponseDTO<string>> BookRoomAsync(BookingRequestDto bookingRequest)
        {
            try
            {
                var customer = await _hotelRepository.GetCustomerByNationalIDAsync(bookingRequest.NationalID);
                if (customer == null)
                {
                    customer = new Customer
                    {
                        Name = bookingRequest.CustomerName,
                        NationalID = bookingRequest.NationalID,
                        PhoneNumber = bookingRequest.PhoneNumber
                    };

                    await _hotelRepository.AddCustomerAsync(customer);
                }

                bool hasPreviousBookings = await _hotelRepository.HasPreviousBookingAsync(bookingRequest.NationalID);

                var booking = _mapper.Map<Booking>(bookingRequest);
                booking.CustomerID = customer.ID;
                booking.DiscountApplied = hasPreviousBookings;

                await _hotelRepository.AddBookingAsync(booking);

                return new CustomResponseDTO<string>
                {
                    Data = $"Booking created successfully with ID: {booking.BookingID}",
                    Message = "Booking created successfully.",
                    Succeeded = true,
                    Errors = null,
                    DiscountApplied = hasPreviousBookings

                };
            }
            catch (Exception ex)
            {
                return new CustomResponseDTO<string>
                {
                    Data = null,
                    Message = "An error occurred while booking the room.",
                    Succeeded = false,
                    Errors = new List<string> { ex.Message },
                    DiscountApplied = false

                };
            }
        }
    }
}
