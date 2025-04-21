using Application.Services.Interfaces;
using Domain.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace FinalExamAsd.Controllers
{
    [ApiController]
    [Route("api/v1/satellites")]
    public class SatelliteController : ControllerBase
    {
        private readonly ISatelliteService _satelliteService;

        public SatelliteController(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateSatelliteRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _satelliteService.UpdateAsync(id, request);
            return Ok(updated);
        }
    }
}
