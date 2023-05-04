using AutoMapper;
using InvitationManagerAPI.Data;
using InvitationManagerAPI.Dtos.User;
using InvitationManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace InvitationManagerAPI.Services.userServices
{
    public class UserService : IUserService
    {
        private static List<protokollUser> users = new List<protokollUser>
        {
            new protokollUser (),
            new protokollUser { name = "nagy sanyi", Id = 1}
        };
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var user = _mapper.Map<protokollUser>(newUser);
            user.Id = users.Max(x => x.Id) + 1;
            users.Add(user);
            serviceResponse.Data = users.Select(x => _mapper.Map<GetUserDto>(x)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var user = users.First(c => c.Id == id);

                if (user == null)               
                    throw new Exception($"Felhasználó '{id}' Id val nem található");
               
                users.Remove(user);

                serviceResponse.Data = users.Select(x => _mapper.Map<GetUserDto>(x)).ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUser()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var dbUsers = await _context.Users.ToListAsync();
            serviceResponse.Data = dbUsers.Select(x => _mapper.Map<GetUserDto>(x)).ToList();
            return serviceResponse;
        }
        
        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var dbUser = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(dbUser);
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {              
                var user = users.FirstOrDefault(user => user.Id == updatedUser.Id);
                if(user == null) 
                {
                    throw new Exception($"Felhasználó '{updatedUser.Id}' Id val nem található");
                };           
                user.name = updatedUser.name;
                user.email = updatedUser.email;
                user.telefonszám = updatedUser.telefonszám;
                user.erzekenysegek = updatedUser.erzekenysegek;
                user.vallás = updatedUser.vallás;
                user.fogyatékosság = updatedUser.fogyatékosság;
                user.titulus = updatedUser.titulus;
                user.userType = updatedUser.userType;
                user.ProfilePic = updatedUser.ProfilePic;
                user.utolsóesemény = updatedUser.utolsóesemény;

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
                
            }
            catch(Exception ex) 
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;               
            }
            return serviceResponse;

        }
    }
}
