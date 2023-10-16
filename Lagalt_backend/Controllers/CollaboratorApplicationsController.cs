using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
using System.Net.Mime;
using AutoMapper;
using Lagalt_backend.Services.Projects;
using Lagalt_backend.Services.Applications;
using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.DTOs.Projects;

namespace Lagalt_backend.Controllers {
    [Route("api/v1/CollaboratorApplications")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CollaboratorApplicationsController : ControllerBase {
        private readonly IApplicationService _service;
        private readonly IMapper _mapper;

        public CollaboratorApplicationsController(IApplicationService applicationService, IMapper mapper) {
            _service = applicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationDTO>>> GetCollaboratorApplications() {
            return Ok(_mapper
                .Map<IEnumerable<ApplicationDTO>>(
                await _service.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CollaboratorApplication>> GetCollaboratorApplication(int id) {
            try {
                var application = await _service.GetByIdAsync(id);
                return _mapper.Map<CollaboratorApplication>(application);
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationDTO>> CreateApplication(ApplicationPostDTO application) {
            var newApplication = await _service.CreateApplication(_mapper.Map<CollaboratorApplication>(application));
            return CreatedAtAction("CreateApplication",
                new { id = newApplication.Id },
                _mapper.Map<ApplicationPostDTO>(newApplication));
        }

        [HttpPost("Accept/{id}")]
        public async Task<IActionResult> AcceptApplication(int id) {
            try {
                await _service.AcceptApplication(id);
                return Ok();
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollaboratorApplication(int id) {
            try {
                await _service.DeleteByIdAsync(id);
                return NoContent();
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }





        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCollaboratorApplication(int id, CollaboratorApplication collaboratorApplication) {
        //    if (id != collaboratorApplication.Id) {
        //        return BadRequest();
        //    }

        //    _context.Entry(collaboratorApplication).State = EntityState.Modified;

        //    try {
        //        await _context.SaveChangesAsync();
        //    } catch (DbUpdateConcurrencyException) {
        //        if (!CollaboratorApplicationExists(id)) {
        //            return NotFound();
        //        } else {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //private bool CollaboratorApplicationExists(int id) {
        //    return (_context.CollaboratorApplications?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
