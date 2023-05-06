using InvitationManagerAPI.Dtos.User;
using InvitationManagerAPI.Models;

namespace InvitationManagerAPI.Services.userServices
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUser();
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser);

        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);


    }
}
