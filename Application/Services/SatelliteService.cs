using Application.Services.Interfaces;
using AutoMapper;
using Data.Repositories.Interfaces;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using FinalExamAsd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SatelliteService : ISatelliteService
    {
        private readonly ISatelliteRepository _satRepo;
        private readonly IMapper _mapper;

        public SatelliteService(ISatelliteRepository satRepo, IMapper mapper)
        {
            _satRepo = satRepo;
            _mapper = mapper;
        }

        public async Task<SatelliteResponse> UpdateAsync(long id, UpdateSatelliteRequest request)
        {
            var satellite = await _satRepo.GetByIdAsync(id);

            if (satellite == null)
                throw new NotFoundException($"Satellite with ID {id} not found");

            if (satellite.Decommissioned)
                throw new BadRequestException("Cannot update a decommissioned satellite.");

            // update values
            satellite.Name = request.Name;
            satellite.LaunchDate = request.LaunchDate;
            satellite.OrbitType = request.OrbitType;

            var updated = await _satRepo.UpdateAsync(satellite);
            return _mapper.Map<SatelliteResponse>(updated);
        }
    }
}
