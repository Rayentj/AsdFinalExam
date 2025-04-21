using AutoMapper;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Models;

namespace FinalExamAsd.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TestEntity, TestEntityResponseDto>();
            CreateMap<TestEntityRequestDto, TestEntity>();

            CreateMap<CreateAstronautRequest, Astronaut>();
            CreateMap<Astronaut, AstronautResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<Satellite, SatelliteResponse>();
        }
    }
}
