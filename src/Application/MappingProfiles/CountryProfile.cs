using Application.CQRS.Commands;
using Application.Models.ViewModels;
using AutoMapper;
using DAL.Entities;

namespace Application.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryEntity, CountryViewModel>();

            CreateMap<CreateCountryCommand, CountryEntity>();
        }
    }
}