using InvitationManagerAPI.Models;
using InvitationManagerAPI.Services.userServices;
using Microsoft.AspNetCore.Mvc;

namespace InvitationManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<protokollUser> users = new List<protokollUser>
        {
            new protokollUser (),
            new protokollUser { name = "nagy sanyi", Id = 1}
        };
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<protokollUser>> Get()
        {
            return Ok(_userService.GetAllUser());
        }

        [HttpGet("{id}")]
        public ActionResult<List<protokollUser>> GetSingle(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        public ActionResult<List<protokollUser>> AddUser(protokollUser newUser)
        {
            return Ok(_userService.AddUser(newUser));
        }
    }
}

