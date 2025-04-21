using Data.Context;
using Data.Repositories.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SatelliteRepository : ISatelliteRepository
    {
        private readonly ApplicationDbContext _context;

        public SatelliteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Satellite>> GetByIdsAsync(List<long> ids)
        {
            return await _context.Satellites
                .Where(s => ids.Contains(s.Id))
                .ToListAsync();
        }

        public async Task<Satellite?> GetByIdAsync(long id)
        {
            return await _context.Satellites.FindAsync(id);
        }


        public async Task<Satellite> UpdateAsync(Satellite satellite)
        {
            _context.Satellites.Update(satellite);
            await _context.SaveChangesAsync();
            return satellite;
        }
    }
}
