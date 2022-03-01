using Application.CQRS.Commands;
using Application.ViewModels;
using AutoMapper;
using DAL.Entities;

namespace Application.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityEntity, CityViewModel>();

            CreateMap<CreateCityCommand, CityEntity>();
        }
    }
}