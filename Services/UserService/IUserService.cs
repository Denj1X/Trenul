using System;
using NewRepo.Models;
using NewRepo.Models.DTOs.UserDTO;

namespace NewRepo.Services.UserService
{
    public interface IUserService
    {
        UserResponse Authenticate(ContRequestDTO user);

        User GetById(Guid id);

        Task CreateNewUser(ContRequestDTO newUser);

        Task CreateAdmin(ContRequestDTO newUser);

        Task DeleteByEmailAsync(string email);

        Task<List<User>> GetAllUsers();

        Task<List<User>> GetSomeAdmins();
    }
}