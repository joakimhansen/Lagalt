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
using Lagalt_backend.Services.Categories;
using Lagalt_backend.Data.DTOs.Categories;
using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.DTOs.Projects;

namespace Lagalt_backend.Controllers {
    [Route("api/v1/categories")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CategoriesController : ControllerBase {

        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper) {
            _service = categoryService;
            _mapper = mapper;
        }

        // Categories

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriesGetDTO>>> GetCategories() {
            return Ok(_mapper
                .Map<IEnumerable<CategoriesGetDTO>>(
                await _service.GetAllAsync()));
        }

        /*[HttpGet("{id}/u")]
        public async Task<ActionResult<CategoriesGetDTO>> GetCategory(int id) {
            try {
                var category = await _service.GetByIdAsync(id);
                return _mapper.Map<CategoriesGetDTO>(category);
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{id}/a")]
        public async Task<ActionResult<CategoriesGetDTO>> GetCategoryA(int id) {
            try {
                var category = await _service.GetByIdAsync(id);
                return _mapper.Map<CategoriesGetDTO>(category);
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }*/



        /*[HttpPost]
        public async Task<ActionResult<CategoriesGetDTO>> PostCategory(CategoriesPostDTO category) {
            var newCategory = await _service.AddAsync(_mapper.Map<Category>(category));
            return CreatedAtAction("PostCategory",
                new { id = newCategory.Id },
                _mapper.Map<CategoriesGetDTO>(newCategory));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoriesPutDTO category) {
            if (id != category.Id) {
                return BadRequest();
            }
            try {
                await _service.UpdateAsync(_mapper.Map<Category>(category));
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id) {
            try {
                await _service.DeleteByIdAsync(id);
                return NoContent();
            } catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }*/

    }
}
