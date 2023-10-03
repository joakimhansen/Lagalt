using AutoMapper;
using Lagalt_backend.Data.DTOs.Skills;
using Lagalt_backend.Services.Skills;
using Microsoft.AspNetCore.Mvc;

namespace Lagalt_backend.Controllers
{

    [Route("api/v1/Skills")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _service;
        private readonly IMapper _mapper;

        public SkillController(ISkillService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetUsers()
        {
            return Ok(_mapper.Map<IEnumerable<SkillDTO>>(await _service.GetAllAsync()));
        }
    }
}
