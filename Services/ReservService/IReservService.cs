using System;
using NewRepo.Models;
using NewRepo.Models.DTOs.RezervareDTO;

namespace NewRepo.Services.ReservService
{
    public interface IReservService
    {
        Task<RezervareDTO> CreateRezAsync(RezervareDTO rez);
        Task<RezervareDTO> UpdateRezStatus(RezervareDTO rez, bool status);
        Task<IEnumerable<RezervareDTO>> GetOrderByUserId(Guid UserId);
        Task<IEnumerable<RezervareDTO>> GetRejectedRez();
    }
}
