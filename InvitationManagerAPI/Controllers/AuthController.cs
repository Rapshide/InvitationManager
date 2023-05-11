using InvitationManagerAPI.Data;
using InvitationManagerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;


namespace InvitationManagerAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(InvitationManagerDbContext invitationManagerDbContext)
        {
            _invitationManagerDbContext = invitationManagerDbContext;
        }

        private readonly InvitationManagerDbContext _invitationManagerDbContext;

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _invitationManagerDbContext.User.ToListAsync();

            return Ok(users);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AddUser([FromBody] User userRequest)
        {
            userRequest.ID = Guid.NewGuid();

            await _invitationManagerDbContext.User.AddAsync(userRequest);
            await _invitationManagerDbContext.SaveChangesAsync();

            return Ok(userRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _invitationManagerDbContext.User.FirstOrDefaultAsync(x => x.ID == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UserRegister updateUser)
        {
            var user = await _invitationManagerDbContext.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = updateUser.Name;
            user.PhoneNumber = updateUser.PhoneNumber;
            user.Email = updateUser.Email;
            user.Password = updateUser.Password;
            user.Role = updateUser.Role;

            await _invitationManagerDbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute]Guid id)
        {
            var user = await _invitationManagerDbContext.User.FindAsync(id);

            if(user == null) 
            {
                return NotFound(user);
            }

            _invitationManagerDbContext.User.Remove(user);
            await _invitationManagerDbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(UserLogin user)
        {
            

            var dbUser = _invitationManagerDbContext.User.Where(u => u.Email == user.Email && u.Password == user.Password)
                .Select( u => new
                {
                    u.ID,
                    u.Email

                }).FirstOrDefault();

            if(dbUser == null)
            {
                return BadRequest("Nem megfelelő email cím vagy jelszó!");
            }

             return Ok(dbUser);
        }


        //public static User user = new User();

        //private readonly IConfiguration _configuration;

        //public AuthController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //[HttpPost("register")]
        //public ActionResult<User> Register(UserDto request)
        //{
        //    string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        //    user.Email = request.Email;
        //    user.PasswordHash = passwordHash;

        //    return Ok(user);
        //}

        //[HttpPost("login")]
        //public ActionResult<User> Login(UserDto request)
        //{
        //    if(user.Email != request.Email)
        //    {
        //        return BadRequest("Nem létező felhasználónév.");
        //    }

        //    if(!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        //    {
        //        return BadRequest("Nem megfelelő jelszó.");
        //    }

        //    string token = CreateToken(user);

        //    return Ok(token);

        //}

        //private string CreateToken(User user)
        //{
        //    List<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.Email)
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //    var token = new JwtSecurityToken(
        //            claims: claims,
        //            expires: DateTime.Now.AddDays(1),
        //            signingCredentials: creds
        //        );
        //    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        //    return jwt;
        //}
    }
}
