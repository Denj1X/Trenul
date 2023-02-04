using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using BCryptNet = BCrypt.Net.BCrypt;
using NewRepo.Data;
using NewRepo.Helpers.Attributes;
using NewRepo.Helpers.JwtUtils;
using NewRepo.Models;
using NewRepo.Models.DTOs.UserDTO;
using NewRepo.Models.Enums;
using NewRepo.Repositories.UserRepository;

namespace NewRepo.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IUnitOfWork _unitOfWork;
        public IJwtUtils _jwtUtils;
        public IMapper _mapper;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public UserResponse Authenticate(ContRequestDTO model)
        {
            var user = _userRepository.FindByEmail(model.Email);
            if(user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponse(user, jwtToken);
        }

        public async Task CreateAdmin(ContRequestDTO newUser)
        {
            var newDBUser = _mapper.Map<User>(newUser);
            newDBUser.PasswordHash = BCryptNet.HashPassword(newUser.Password);
            newDBUser.Role = Role.Admin;

            await _userRepository.CreateAsync(newDBUser);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteByEmailAsync(string email)
        {
            var user = _userRepository.FindByEmail(email);
            if (user == null)
                return;
            _userRepository.Delete(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return (List<User>)_userRepository.FindAllUsers();
        }

        public async Task<List<User>> GetSomeAdmins()
        {
            return (List<User>)_userRepository.GetAdminsWithRezervations();
        }
    }
}
