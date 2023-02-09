using System;
using Microsoft.EntityFrameworkCore;
using NewRepo.Data;
using NewRepo.Models;
using NewRepo.Repositories.GenericRepository;

namespace NewRepo.Repositories.RezervRepository
{ {
    public class RezervRepository: GenericRepository<Rezervare>, IRezervRepository
    {
        public RezervRepository(DataBaseContext context): base(context)
        {

        }

        public async Task<IEnumerable<Rezervare>> GetRezervareByUserId(Guid UserID)
        {
            return await _context.Reserv
                .Join(_context.Reserv,
                r => r.UserId,
                u => u.UserId,
                (r, u) => new { Rezervare = r, User = u })
                .Where(rez => rez.Rezervare.UserId = UserID)
                .Select(rez => rez.Rezervare)
                .ToListAsync();
        }

        public async Task<IEnumerable<Rezervare>> GetRejectedRezerv()
        {
            return await _context.Reserv
                .Include(o => o.LastName)
                .Where(o => o.IsConfirmed == false)
                .ToListAsync();
        }

        public async Task<Rezervare> AddRezervare(Rezervare rezerv)
        {
            _context.Reserv.Add(rezerv);
            await _context.SaveChangesAsync();
            return rezerv;
        }

        public async Task<Rezervare> UpdateRezervare(Guid RezervareId, bool IsConfirmed)
        {
            var rezerv = await _context.Reserv.FindAsync(RezervareId);
            rezerv.IsConfirmed = IsConfirmed;
            _context.Reserv.Update(rezerv);
            await _context.SaveChangesAsync();
            return rezerv; 
        }
    }
}