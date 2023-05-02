using InvitationManagerAPI.Models;

namespace InvitationManagerAPI.Services.userServices
{
    public class UserService : IUserService
    {
        private static List<protokollUser> users = new List<protokollUser>
        {
            new protokollUser (),
            new protokollUser { name = "nagy sanyi", Id = 1}
        };
        public List<protokollUser> AddUser(protokollUser newUser)
        {
            users.Add(newUser);
            return users;
        }

        public List<protokollUser> GetAllUser()
        {
            return users;
        }

        public protokollUser GetUserById(int id)
        {
            var user = users.FirstOrDefault(c => c.Id == id);

            if (user is not null)
            {
                return user;
            }
            else
            {
                throw new Exception("Nem létező ID");
            }

            
        }
    }
}
