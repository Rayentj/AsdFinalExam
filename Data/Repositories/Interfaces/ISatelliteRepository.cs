using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface ISatelliteRepository
    {
        Task<List<Satellite>> GetByIdsAsync(List<long> ids);
        Task<Satellite?> GetByIdAsync(long id);

        Task<Satellite> UpdateAsync(Satellite satellite);
    }
}
