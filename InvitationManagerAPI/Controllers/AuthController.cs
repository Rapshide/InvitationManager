using InvitationManagerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        public static User user = new User();

<<<<<<< Updated upstream
=======

        private readonly DataContext _dataContext;
>>>>>>> Stashed changes
        private readonly IConfiguration _configuration;

<<<<<<< Updated upstream
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
=======
        public AuthController(IConfiguration configuration, IUserService userService, DataContext invitationManagerDbContext)
        {
            _configuration = configuration;
            _userService = userService;
            _dataContext = invitationManagerDbContext;
>>>>>>> Stashed changes
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.Username = request.Username;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
<<<<<<< Updated upstream
            if(user.Username != request.Username)
=======

            var dbUser = _dataContext.User.Where(u => u.Email == loginUser.Email && u.Password == loginUser.Password)
                .Select(u => new
                {
                    u.ID,
                    u.Email,
                    u.Role

                }).FirstOrDefault();

            if (dbUser == null)
>>>>>>> Stashed changes
            {
                return BadRequest("Nem létező felhasználónév.");
            }

            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Nem megfelelő jelszó.");
            }

            string token = CreateToken(user);

<<<<<<< Updated upstream
            return Ok(token);

=======
            return Ok(dbUser);
>>>>>>> Stashed changes
        }

        private string CreateToken(User user)
        {
<<<<<<< Updated upstream
            List<Claim> claims = new List<Claim>
=======
            userRequest.ID = Guid.NewGuid();

            await _dataContext.User.AddAsync(userRequest);
            await _dataContext.SaveChangesAsync();

            return Ok(userRequest);
        }

        //Összes felhasználó lekérése
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _dataContext.User.ToListAsync();

            return Ok(users);
        }


        //Felhasználó lekérése
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _dataContext.User.FirstOrDefaultAsync(x => x.ID == id);

            if (user == null)
>>>>>>> Stashed changes
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

<<<<<<< Updated upstream
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
=======
            return Ok(user);
        }

        //Felhasználói adatok átírása
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UserUpdate updateUser)
        {
            var user = await _dataContext.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = updateUser.Name;
            user.PhoneNumber = updateUser.PhoneNumber;
            user.Email = updateUser.Email;
            user.Password = updateUser.Password;
            user.Role = updateUser.Role;

            await _dataContext.SaveChangesAsync();
            return Ok(user);
        }


        //Felhasználó törlése
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _dataContext.User.FindAsync(id);

            if (user == null)
            {
                return NotFound(user);
            }

            _dataContext.User.Remove(user);
            await _dataContext.SaveChangesAsync();
            return Ok(user);
        }
 

        private string CreateToken(List<Claim> claims)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));
>>>>>>> Stashed changes

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
