using System.Linq;
using Application.ViewModels;
using AutoMapper;
using DAL.Entities;

namespace Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserViewModel>()
                .ForMember(src => src.UserImageId, act => act.MapFrom(dest => dest.UserImage.Id))
                .ForMember(src => src.Roles, act => act.MapFrom(dest => dest.UserRoles.Select(r => r.Role)));
        }
    }
}