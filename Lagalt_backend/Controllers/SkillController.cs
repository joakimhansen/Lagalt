/*using AutoMapper;
using Lagalt_backend.Data.DTOs.Skills;
using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models.Entities;
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
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetSkills()
        {
            return Ok(_mapper.Map<IEnumerable<SkillDTO>>(await _service.GetAllAsync()));
        }

        *//*[HttpGet("{id}")]
        public async Task<ActionResult<SkillDTO>> GetSkill(int id)
        {
            try
            {
                return Ok(_mapper.Map<SkillDTO>(await _service.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SkillDTO>> PostSkill(SkillPostDTO skill)
        {
            var newSkill = await _service.AddAsync(_mapper.Map<Skill>(skill));
            return CreatedAtAction("GetSkill",
                new { id = newSkill.Id },
                _mapper.Map<SkillDTO>(newSkill));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, SkillPutDTO skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(_mapper.Map<Skill>(skill));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            try
            {
                await _service.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }*//*
    }
}
*/