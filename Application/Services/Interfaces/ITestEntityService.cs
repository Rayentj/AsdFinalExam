using Domain.DTOs.Request;
using Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITestEntityService
    {
        Task<IEnumerable<TestEntityResponseDto>> GetAllAsync(int page, int size);
        Task<TestEntityResponseDto?> GetByIdAsync(int id);
        Task<TestEntityResponseDto> CreateAsync(TestEntityRequestDto dto);
        Task DeleteAsync(int id);
    }
}
