using Application.ViewModels;
using AutoMapper;
using DAL.Entities;

namespace Application.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleEntity, RoleViewModel>();
        }
    }
}