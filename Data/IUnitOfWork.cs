using System;
using NewRepo.Repositories.UserRepository;

namespace NewRepo.Data
{
    public interface IUnitOfWork
    {
        DataBaseContext Context { get; }
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
