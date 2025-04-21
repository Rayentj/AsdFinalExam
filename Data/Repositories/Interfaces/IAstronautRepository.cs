using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IAstronautRepository
    {
        Task<Astronaut> AddAsync(Astronaut astronaut);
        Task<List<Astronaut>> GetAllSortedByExperienceAsync(string order);
        Task<Astronaut?> GetByIdAsync(long id);
    }

}
