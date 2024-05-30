using AutoMapper;
using WEBAPI.DTOs;
using WEBAPI.Entities;

namespace WEBAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingRequestDto, Booking>()
                .ForMember(dest => dest.BookingRooms, opt => opt.MapFrom(src => src.Rooms));

            CreateMap<RoomDto, BookingRoom>();
            CreateMap<HotelBranch, BranchDto>();

        }
    }
}