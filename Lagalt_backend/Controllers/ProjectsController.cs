using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
using Lagalt_backend.Services.Projects;
using AutoMapper;
using Lagalt_backend.Data.DTOs.Projects;
using Lagalt_backend.Data.Exceptions;
using System.Net.Mime;
using System.Web;

namespace Lagalt_backend.Controllers {
    [Route("api/v1/projects")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProjectsController : ControllerBase {

        private readonly IProjectService _service;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper) {
            _service = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectsListDTO>>> GetProjects() {
            return Ok(_mapper
                .Map<IEnumerable<ProjectsListDTO>>(
                await _service.GetAllAsync()));
        }

        [HttpGet("{id}/u")]
        public async Task<ActionResult<ProjectsUAuthGetDTO>> GetProject(int id) {
            try {
                var project = await _service.GetByIdAsync(id);
                return _mapper.Map<ProjectsUAuthGetDTO>(project);
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{id}/a")]
        public async Task<ActionResult<ProjectsAuthGetDTO>> GetProjectA(int id) {
            try {
                var project = await _service.GetByIdAsync(id);
                return _mapper.Map<ProjectsAuthGetDTO>(project);
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, [FromForm] ProjectsPutDTO project) {
            if (id != project.Id) {
                return BadRequest();
            }
            try {
                await _service.UpdateAsync(_mapper.Map<Project>(project));
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id) {
            try {
                await _service.DeleteByIdAsync(id);
                return NoContent();
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        /*
                [HttpPost]
                public async Task<ActionResult<ProjectsGetDTO>> PostProject(ProjectsPostDTO project) {
                    var newProject = await _service.AddAsync(_mapper.Map<Project>(project));
                    return CreatedAtAction("PostProject",
                        new { id = newProject.Id },
                        _mapper.Map<ProjectsGetDTO>(newProject));
                }

                [HttpPut("{id}")]
                public async Task<IActionResult> PutProject(int id, ProjectsPutDTO project) {
                    if (id != project.Id) {
                        return BadRequest();
                    }
                    try {
                        await _service.UpdateAsync(_mapper.Map<Project>(project));
                    } catch (EntityNotFoundException ex) {
                        return NotFound(ex.Message);
                    }
                    return NoContent();
                }

        */
    }
}
