using Application.Services;
using Application.Services.Interfaces;
using Domain.DTOs.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace FinalExamAsd.Controllers
{
    [ApiController]
    [Route("api/v1/astronauts")]
    public class AstronautsController : ControllerBase
    {
        private readonly IAstronautService _service;
        public AstronautsController(IAstronautService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody][Required] CreateAstronautRequest request)
        {
            var result = await _service.CreateAstronautAsync(request);
            return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string sort = "asc")
        {
            var result = await _service.GetAllAsync(sort);
            return Ok(result);
        }
    }

}
