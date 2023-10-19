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

        /// <summary>
        /// Get all the projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectsListDTO>>> GetProjects() {
            return Ok(_mapper
                .Map<IEnumerable<ProjectsListDTO>>(
                await _service.GetAllAsync()));
        }

        /// <summary>
        /// Get a spesific project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/u")]
        public async Task<ActionResult<ProjectsUAuthGetDTO>> GetProject(int id) {
            try {
                var project = await _service.GetByIdAsync(id);
                return _mapper.Map<ProjectsUAuthGetDTO>(project);
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Get a spesific project by id when authenticated/logged in
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/a")]
        public async Task<ActionResult<ProjectsAuthGetDTO>> GetProjectA(int id) {
            try {
                var project = await _service.GetByIdAsync(id);
                return _mapper.Map<ProjectsAuthGetDTO>(project);
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Change a project by id (full-description and progress)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, [FromForm] ProjectsPutDTO UpdatedValues) {
            if (id != UpdatedValues.Id)
                return BadRequest($"Object id {UpdatedValues.Id} does not match project referenced in API-endpoint /api/v1/projects/{id}");

            if (!(new int[] { 0, 1, 2, 3 }).Contains(UpdatedValues.Progress))
                return BadRequest($"{UpdatedValues.Progress} is not a valid input for progress");

            try
            {
                await _service.UpdateAsync(_mapper.Map<Project>(UpdatedValues));
                return NoContent();
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Delete a project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id) {
            try {
                await _service.DeleteByIdAsync(id);
                return NoContent();
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

    }
}
