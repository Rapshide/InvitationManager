using AutoMapper;
using InvitationManagerAPI.Dtos.User;
using InvitationManagerAPI.Models;

namespace InvitationManagerAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<protokollUser, GetUserDto>();

            CreateMap<AddUserDto, protokollUser>();
        }
    }
}
