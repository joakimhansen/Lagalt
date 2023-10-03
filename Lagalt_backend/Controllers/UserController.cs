using AutoMapper;
using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Models.Entities;
using Lagalt_backend.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Lagalt_backend.Controllers
{
    [Route("api/v1/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly UserService _service;
        private readonly IMapper _mapper;

        public UserController(UserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(await _service.GetAllAsync()));
        }
    }
}
