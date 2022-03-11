using Application.CQRS.Commands;
using AutoMapper;
using DAL.Entities;

namespace Application.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<CreateBookingCommand, BookingEntity>();
        }
    }
}