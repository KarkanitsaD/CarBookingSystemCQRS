using Application.CQRS.Commands;
using Application.Models.ViewModels;
using AutoMapper;
using DAL.Entities;

namespace Application.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<CreateBookingCommand, BookingEntity>();

            CreateMap<BookingEntity, BookingViewModel>();
        }
    }
}