using Application.Services.Interfaces;
using AutoMapper;
using Data.Repositories.Interfaces;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TestEntityService : ITestEntityService
    {
        private readonly ITestEntityRepository _repository;
        private readonly IMapper _mapper;

        public TestEntityService(ITestEntityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestEntityResponseDto>> GetAllAsync(int page, int size)
        {
            var entities = await _repository.GetAllAsync(page, size);
            return _mapper.Map<IEnumerable<TestEntityResponseDto>>(entities);
        }

        public async Task<TestEntityResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<TestEntityResponseDto>(entity);
        }

        public async Task<TestEntityResponseDto> CreateAsync(TestEntityRequestDto dto)
        {
            var entity = _mapper.Map<TestEntity>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<TestEntityResponseDto>(created);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
