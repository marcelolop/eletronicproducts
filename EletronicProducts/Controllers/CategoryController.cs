using AutoMapper;
using BLL.Dependency_Interfaces;
using Microsoft.AspNetCore.Http;
using Entities.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Entities.Models.DTOs.CategoryDTOs;

namespace EletronicProducts.Controllers
{
    [Route("api")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //Dependency Injection
        private IMapper _mapper;
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns> List of all categories</returns>
        [HttpGet, Route("categories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                if (categories == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No categories found");
                }
                var categoriesDTO = _mapper.Map<List<CategoryReadDto>>(categories);
                return StatusCode(StatusCodes.Status200OK, categoriesDTO);
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Get category by Id
        /// </summary>
        /// <param name="Id"> Category Id</param>
        /// <returns> Ok response with category details</returns>
        [HttpGet, Route("categories/{Id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int Id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(Id);
                if (category == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Category with ID: {Id} not found");
                }
                var categoryDTO = _mapper.Map<CategoryReadDto>(category);
                return StatusCode(StatusCodes.Status200OK, categoryDTO);
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Add category
        /// </summary>
        /// <param name="categoryCreateDto"> Category data transfer object</param>
        /// <returns> Created category</returns>
        [HttpPost, Route("categories")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryAdd_UpdateDto categoryCreateDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryCreateDto);
                var addedCategory = await _categoryService.AddCategoryAsync(category);
                var categoryDTO = _mapper.Map<CategoryReadDto>(addedCategory);
                return StatusCode(StatusCodes.Status201Created, categoryDTO);
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="Id"> Category Id</param>
        /// <param name="categoryUpdateDto"> Category data transfer object</param>
        /// <returns> Updated category</returns>
        [HttpPut, Route("categories")]
        public async Task<IActionResult> UpdateCategoryAsync(int Id, [FromBody] CategoryAdd_UpdateDto categoryUpdateDto)
        {
            if(categoryUpdateDto == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "CategoryUpdateDTO is null");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(Id);
                if (category == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Category with ID: {Id} not found");
                }
                _mapper.Map(categoryUpdateDto, category);
                var updatedCategory = await _categoryService.UpdateCategoryAsync(category);

                if (updatedCategory == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Couldn't update category");
                }

                var categoryDTO = _mapper.Map<CategoryReadDto>(updatedCategory);

                return StatusCode(StatusCodes.Status200OK, categoryDTO);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="Id"> Category Id</param>
        /// <returns> Deleted category</returns>
        [HttpDelete, Route("categories/{Id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int Id)
        {
            if (Id <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Invalid product ID");
            }

            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(Id);
                if (category == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Category with ID: {Id} not found");
                }
                var deletedCategory = await _categoryService.DeleteCategoryAsync(Id);
                var categoryDTO = _mapper.Map<CategoryReadDto>(deletedCategory);
                return StatusCode(StatusCodes.Status200OK, categoryDTO);
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
