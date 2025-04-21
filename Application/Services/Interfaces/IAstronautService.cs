using Domain.DTOs.Request;
using Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAstronautService
    {
        Task<AstronautResponse> CreateAstronautAsync(CreateAstronautRequest request);
        Task<List<AstronautResponse>> GetAllAsync(string order);
    }

}
