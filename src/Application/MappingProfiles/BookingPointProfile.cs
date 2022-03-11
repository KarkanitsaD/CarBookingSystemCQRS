using Application.Models.ViewModels;
using AutoMapper;
using DAL.Entities;

namespace Application.MappingProfiles
{
    public class BookingPointProfile : Profile
    {
        public BookingPointProfile()
        {
            CreateMap<BookingPointEntity, BookingPointViewModel>()
                .ForMember(src => src.City, act => act.MapFrom(dest => dest.City.Title))
                .ForMember(src => src.Country, act => act.MapFrom(dest => dest.City.Country.Title));
        }
    }
}