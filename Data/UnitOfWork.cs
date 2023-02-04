using System;
using Microsoft.Data.SqlClient;
using NewRepo.Repositories.UserRepository;

namespace NewRepo.Data
{
    public class UnitOfWork : IUnitOfWork
    {   private readonly DataBaseContext _context;
        private IUserRepository? _userRepository;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        public DataBaseContext Context
        {
            get { return _context; }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository; }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}