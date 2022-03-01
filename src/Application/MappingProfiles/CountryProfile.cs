using Application.CQRS.Commands;
using Application.ViewModels;
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