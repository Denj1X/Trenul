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

        async Task<RezervareDTO> CreateRezAsync(RezervareDTO rez)
        {
            var rezModel = _mapper.Map<Rezervare>(rez);
            var addRez = await _rezervRepository.AddRezervare(rezModel);
            return _mapper.Map<RezervareDTO>(addRez);
        }


    }
}
