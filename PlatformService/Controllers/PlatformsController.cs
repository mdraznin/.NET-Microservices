using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mido.PlatformService.Data;
using Mido.PlatformService.Dtos;

namespace Mido.PlatformService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms() 
        {
            Console.WriteLine("--> Getting all Platforms...");

            var platformItems = _repository.GetAllPlatforms();
            
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }
    }
}