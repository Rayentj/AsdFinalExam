using Domain.DTOs.Request;
using Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ISatelliteService
    {
        Task<SatelliteResponse> UpdateAsync(long id, UpdateSatelliteRequest request);

    }
}
