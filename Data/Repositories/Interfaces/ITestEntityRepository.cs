using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface ITestEntityRepository
    {
        Task<IEnumerable<TestEntity>> GetAllAsync(int pageNumber, int pageSize);
        Task<TestEntity?> GetByIdAsync(int id);
        Task<TestEntity> AddAsync(TestEntity entity);
        Task DeleteAsync(int id);
    }
}
