using AutoMapper;
using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models.Entities;
using Lagalt_backend.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Lagalt_backend.Controllers {
    [Route("api/v1/Users")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper) {
            _service = service;
            _mapper = mapper;
        }

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(await _service.GetAllAsync()));
        }*/

        /// <summary>
        /// Get a spesific user by username. If user doesn't exist, create a user with that username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("{username}")]
        public async Task<ActionResult<UserDTO>> GetUser(string username) {
            try {
                return Ok(_mapper.Map<UserDTO>(await _service.GetByIdAsync(username)));
            } catch (UserNotFoundException ex) {
                return Ok(_mapper.Map<UserDTO>(await _service.AddAsync(new User {Username = username})));
                //return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Change an exsiting user by username (info, image-url, hidden)
        /// </summary>
        /// <param name="username"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPut("{username}")]
        public async Task<IActionResult> PutUser(string username, UserPutDTO User) {
            if (username != User.Username) {
                return BadRequest();
            }

            try {
                await _service.UpdateAsync(_mapper.Map<User>(User));
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
        /*
                [HttpPost]
                public async Task<ActionResult<UserDTO>> PostUser(UserPostDTO User)
                {
                    var newUser = await _service.AddAsync(_mapper.Map<User>(User));

                    return CreatedAtAction("GetUser",
                        new { id = newUser.Id },
                        _mapper.Map<UserDTO>(newUser));
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
                }*/
    }
}
