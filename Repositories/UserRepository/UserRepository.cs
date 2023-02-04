using NewRepo.Data;
using NewRepo.Models;
using NewRepo.Models.Base.Roles;
using NewRepo.Repositories.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using NewRepo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NewRepo.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CatForumContext context) : base(context)
        {

        }

        public async IEnumerable<User> FindAllUsers()
        {
            var empls = _table.ToList();
            return empls.Where(o => o.Role == Role.User);
        }

        public User? FindByEmail(string email)
        {
            if (email != null)
            {
                return _table.FirstOrDefault(o => o.Email == email);
            }
            else return null;
        }

        public async Task<IEnumerable<User>> GetAdminsWithRezervations()
        {
            return await _table.Where(o => o.Role == Role.Admin).Include(u => u.rez).ToListAsync();
        }
    }
}