﻿using System;
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

        /// <summary>
        /// Post a new collaboration-application
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ApplicationDTO>> AddApplication([FromForm] ApplicationPostDTO application) {
            var newApplication = await _service.AddAsync(_mapper.Map<CollaboratorApplication>(application));
            return CreatedAtAction("CreateApplication",
                new { id = newApplication.Id },
                _mapper.Map<ApplicationPostDTO>(newApplication));
        }

        /// <summary>
        /// Accept a new application from a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Accept/{id}")]
        public async Task<IActionResult> AcceptApplication(int id) {
            try {
                await _service.AcceptApplication(id);
                return Ok();
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            } catch (CollaboratorExistsException ex)
            {
                return NotFound(ex.Message);
            }
        }


        /// <summary>
        /// Delete a collaboration-application from a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollaboratorApplication(int id) {
            try {
                await _service.DeleteByIdAsync(id);
                return NoContent();
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

    }
}
