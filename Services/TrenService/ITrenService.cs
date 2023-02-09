using System;
using NewRepo.Models.DTOs.TrenDTO;

namespace NewRepo.Services.TrenService
{
    public interface ITrenService
    {
        IEnumerable<TrenDTO> GetTrenMappedByPlecare(string plecare);
        Task<TrenDTO> AddTren(TrenDTO tren);
        Task<TrenDTO> UpdateTren(TrenDTO tren, string loc_sosire);
        Task<TrenDTO> DeleteTren(Guid id);
        Task<TrenDTO> GetTren(Guid id);
    }
}
