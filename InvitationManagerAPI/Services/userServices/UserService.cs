﻿using AutoMapper;
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
            var dbUser = _mapper.Map<protokollUser>(newUser);
            dbUser.Id = _context.Users.Max(x => x.Id) + 1;
            _context.Users.Add(dbUser);
            serviceResponse.Data = users.Select(x => _mapper.Map<GetUserDto>(x)).ToList();
            await _context.SaveChangesAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var dbUser = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);

                if (dbUser == null)               
                    throw new Exception($"Felhasználó '{id}' Id val nem található");
               
                _context.Users.Remove(dbUser);

                await _context.SaveChangesAsync();

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
