using System;
using NewRepo.Models;
using NewRepo.Models.DTOs.RezervareDTO;
using NewRepo.Repositories.RezervRepository;

namespace NewRepo.Services.ReservService
{
    public class ReservService: IReservService
    {
        private readonly IRezervRepository _rezervRepository;
        private readonly IMapper _mapper;

        public ReservService(IRezervRepository rezervRepository, IMapper mapper)
        {
            _rezervRepository = rezervRepository;
            _mapper = mapper;
        }

        public async Task<RezervareDTO> CreateRezAsync(RezervareDTO rez)
        {
            var rezModel = _mapper.Map<Rezervare>(rez);
            var addRez = await _rezervRepository.AddRezervare(rezModel);
            return _mapper.Map<RezervareDTO>(addRez);
        }

        public async async UpdateRezStatus(RezervareDTO rez, bool status)
        {
            var rezUpdate = _mapper.Map<Rezervare>(rez);
            var updatedRez = await _rezervRepository.UpdateRezervare(rezUpdate.UserId, status);
            return _mapper.Map<RezervareDTO>(updatedRez);
        }

        public async Task<IEnumerable<RezervareDTO>> GetOrderByUserId(Guid UserId)
        {
            var rezs = await _rezervRepository.GetRezervareByUserId(UserId);
            return _mapper.Map<List<RezervareDTO>>(rezs);
        }

        async Task<IEnumerable<RezervareDTO>> GetRejectedRez()
        {
            var rezs = await _rezervRepository.GetRejectedRezerv();
            return _mapper.Map<List<RezervareDTO>>(rezs);
        }
    }
}
