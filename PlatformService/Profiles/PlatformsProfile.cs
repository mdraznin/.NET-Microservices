using AutoMapper;
using Mido.PlatformService.Dtos;
using Mido.PlatformService.Models;

namespace Mido.PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source to target 
            // Reading data >> Model to DTO
            CreateMap<Platform, PlatformReadDto>();

            // Writing data >> PlatformCreateDto is a source as a consumer sends data to model 
            CreateMap<PlatformCreateDto, Platform>();

        }
    }
}