using System;
using NewRepo.Models;
using NewRepo.Repositories.GenericRepository;

namespace NewRepo.Repositories.TrenRepository
{
    public interface ITrenRepository : IGenericRepository<Tren>
    {
        public void OrderByPasageri(bool descending);
        Task<IEnumerable<Tren>> GetBySize(int size);
        Task<IEnumerable<Tren>> GetByPlecareAsync(string plecare);
        Task<Tren> UpdateTren(Guid id, string loc_sosire);
        Task<Tren> AddTren(Tren tren);
        Task<Tren> DeleteTren(Guid id);
        Task<Tren> GetTren(Guid id);
    }
}
