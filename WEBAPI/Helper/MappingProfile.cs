using AutoMapper;
using WEBAPI.DTOs;
using WEBAPI.Entities;

namespace WEBAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingRequestDto, Booking>();


            CreateMap<RoomDto, BookingRoom>();


            CreateMap<HotelBranch, BranchDto>();

        }
    }
}