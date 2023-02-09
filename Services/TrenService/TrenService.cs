using System;
using AutoMapper;
using NewRepo.Models.DTOs.TrenDTO;
using NewRepo.Models;
using NewRepo.Repositories.TrenRepository;

namespace NewRepo.Services.TrenService
{
    public class TrenService: ITrenService
    {
        private readonly ITrenRepository _trenRepository;
        private readonly IMapper _mapper;

        public TrenService(ITrenRepository trenRepository, IMapper mapper)
        {
            _trenRepository = trenRepository;
            _mapper = mapper;
        }

        public IEnumerable<TrenDTO> GetTrenMappedByPlecare(string plecare)
        {
            IEnumerable<Tren> trenuri = (IEnumerable<Tren>)_trenRepository.GetByPlecareAsync(plecare);
            IEnumerable<TrenDTO> trenRes = trenuri.Select(p => _mapper.Map<TrenDTO>(p));
            return trenRes;
        }

        public async Task<TrenDTO> AddTren(TrenDTO tren)
        {
            var TrenModel = _mapper.Map<tren>(tren);
            var addedTren = await _trenRepository.AddTren(TrenModel);
            return _mapper.Map<TrenDTO>(addedTren);
        }

        public async Task<TrenDTO> UpdateTren(TrenDTO tren, string loc_sosire)
        {
            var TrenModel = _mapper.Map<tren>(tren);
            var updatedTren = await _trenRepository.Update(TrenModel.TrenId, loc_sosire);
            return _mapper.Map<Tren>(updatedTren);
        }

        public async Task<TrenDTO> DeleteTren(Guid id)
        {
            var deletedTren = await _trenRepository.DeleteTren(id);
            return _mapper.Map<TrenDTO>(deletedTren);
        }

        public async Task<TrenDTO> GetTren(Guid id)
        {
            return _mapper.Map<TrenDTO>(await _trenRepository.GetTren(id));
        }
    } 
}