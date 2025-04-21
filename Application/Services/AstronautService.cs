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
using FinalExamAsd.Exceptions;


namespace Application.Services
{
    public class AstronautService : IAstronautService
    {
        private readonly IAstronautRepository _astroRepo;
        private readonly ISatelliteRepository _satRepo;
        private readonly IMapper _mapper;

        public AstronautService(IAstronautRepository astroRepo, ISatelliteRepository satRepo, IMapper mapper)
        {
            _astroRepo = astroRepo;
            _satRepo = satRepo;
            _mapper = mapper;
        }

        public async Task<AstronautResponse> CreateAstronautAsync(CreateAstronautRequest request)
        {
            var satellites = await _satRepo.GetByIdsAsync(request.SatelliteIds);

            // ❌ Validate satellite count
            if (satellites.Count != request.SatelliteIds.Count)
                throw new BadRequestException("One or more satellite IDs are invalid");

            var astronaut = _mapper.Map<Astronaut>(request);
            astronaut.Satellites = satellites;

            var saved = await _astroRepo.AddAsync(astronaut);
            return _mapper.Map<AstronautResponse>(saved);
        }

        public async Task<List<AstronautResponse>> GetAllAsync(string order)
        {
            var data = await _astroRepo.GetAllSortedByExperienceAsync(order);
            return _mapper.Map<List<AstronautResponse>>(data);
        }
    }

}
