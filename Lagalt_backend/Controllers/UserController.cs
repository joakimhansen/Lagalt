using AutoMapper;
using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models.Entities;
using Lagalt_backend.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Lagalt_backend.Controllers
{
    [Route("api/v1/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(await _service.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            try
            {
                return Ok(_mapper.Map<UserDTO>(await _service.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserPostDTO User)
        {
            var newUser = await _service.AddAsync(_mapper.Map<User>(User));

            return CreatedAtAction("GetUser",
                new { id = newUser.Id },
                _mapper.Map<UserDTO>(newUser));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserPutDTO User)
        {
            if (id != User.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(_mapper.Map<User>(User));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
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
        }
    }
}
