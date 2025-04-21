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
    public class TestEntityRepository : ITestEntityRepository
    {
        private readonly ApplicationDbContext _context;

        public TestEntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TestEntity>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.TestEntities
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<TestEntity?> GetByIdAsync(int id)
        {
            return await _context.TestEntities.FindAsync(id);
        }

        public async Task<TestEntity> AddAsync(TestEntity entity)
        {
            _context.TestEntities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TestEntities.FindAsync(id);
            if (entity != null)
            {
                _context.TestEntities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
