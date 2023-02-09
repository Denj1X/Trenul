using System;
using NewRepo.Models;
using NewRepo.Repositories.GenericRepository;

namespace NewRepo.Repositories.RezervRepository
{
    public interface IRezervRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Rezervare>> GetRezervareByUserId(Guid UserID);
        Task<IEnumerable<Rezervare>> GetRejectedRezerv();
        Task<Rezervare> AddRezervare(Rezervare rezerv);
        Task<Rezervare> UpdateRezervare(Guid RezervareId, bool IsConfirmed);
    }
}