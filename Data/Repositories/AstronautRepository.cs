using Data.Context;
using Data.Repositories.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AstronautRepository : IAstronautRepository
    {
        private readonly ApplicationDbContext _context;
        public AstronautRepository(ApplicationDbContext context) => _context = context;

        public async Task<Astronaut> AddAsync(Astronaut astronaut)
        {
            _context.Astronauts.Add(astronaut);
            await _context.SaveChangesAsync();
            return astronaut;
        }

        public async Task<List<Astronaut>> GetAllSortedByExperienceAsync(string order)
        {
            var query = _context.Astronauts.Include(a => a.Satellites).AsQueryable();
            return order.ToLower() == "desc"
                ? await query.OrderByDescending(a => a.ExperienceYears).ToListAsync()
                : await query.OrderBy(a => a.ExperienceYears).ToListAsync();
        }

        public async Task<Astronaut?> GetByIdAsync(long id)
        {
            return await _context.Astronauts.Include(a => a.Satellites)
                                            .FirstOrDefaultAsync(a => a.Id == id);
        }
    }

}
