using system;
using NewRepo.Models;
using NewRepo.Repositories.GenericRepository;

namespace NewRepo.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? FindByEmail(string email);
        IEnumerable<User> FindAllUsers();

        Task<IEnumerable<User>> GetAdminsWithRezervations();
    }
}