using System;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using NewRepo.Data;
using NewRepo.Models;
using NewRepo.Repositories.GenericRepository;

namespace NewRepo.Repositories.TrenRepository
{
    public class TrenRepository: GenericRepository<Tren>, ITrenRepository
    {
        public TrenRepository(DataBaseContext context): base(context)
        {

        }

        public void OrderByPasageri(bool descending)
        {
            if(descending == false)
            {
                var trenOrderAscending = _OrderBy(x => x.Vagoane * x.locuri_per_vagon);
                var trenOrderAscending2 = from s in _table
                                          orderby s.Vagoane * s.locuri_per_vagon
                                          select s;
            }

            else
            {
                var trenOrderAscending = _OrderByDescending(x => x.Vagoane * x.locuri_per_vagon);
                var trenOrderAscending2 = from s in _table
                                          orderby s.Vagoane * s.locuri_per_vagon descending
                                          select s;
            }
        }

        public async Task<IEnumerable<Tren>> GetBySize(int size)
        {
            return await _context.Trenuri
                .Include(t => t.TrenId)
                .Where(t => t.Vagoane == size)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tren>> GetByPlecareAsync(string plecare)
        {
            return await _context.Trenuri
                .Include(t => t.TrenId)
                .Where(t => t.loc_plecare == plecare)
                .ToListAsync();
        }

        public async Task<Tren> UpdateTren(Guid id, bool loc_sosire)
        {
            var tren = await _context.Trenuri.FindAsync(id);
            tren.loc_sosire = loc_sosire;
            _context.Trenuri.Update(tren);
            await _context.SaveChanges.Async();
            return tren;
        }

        async Task<Tren> AddTren(Tren tren)
        {
            _context.Trenuri.Add(tren);
            await _context.SaveChangesAsync();
            return tren;
        }

        async Task<Tren> DeleteTren(Guid id)
        {
            var tren = await _context.Trenuri.FindAsync(id);
            _context.Trenuri.Remove(tren);
            await _context.SaveChangesAsync();
            return tren;
        }

        async Task<Tren> GetTren(Guid id)
        {
            return await _context.Trenuri.FindAsync(id);
        }
    }
}
