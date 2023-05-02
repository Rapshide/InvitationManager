using InvitationManagerAPI.Models;

namespace InvitationManagerAPI.Services.userServices
{
    public interface IUserService
    {
        List<protokollUser> GetAllUser();
        protokollUser GetUserById(int id);

        List<protokollUser> AddUser(protokollUser newUser);
    }
}
