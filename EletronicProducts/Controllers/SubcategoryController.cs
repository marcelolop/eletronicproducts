using AutoMapper;
using BLL.Dependency_Interfaces;
using Microsoft.AspNetCore.Http;
using Entities.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Entities.Models.DTOs.SubcategoryDTOs;

namespace EletronicProducts.Controllers
{
    [Route("api")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        //Dependency Injection
        private IMapper _mapper;
        private ISubcategoryService _subcategoryService;

        public SubcategoryController(ISubcategoryService subcategoryService, IMapper mapper)
        {
            _subcategoryService = subcategoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all subcategories
        /// </summary>
        /// <returns> List of all subcategories</returns>
        [HttpGet,Route("subcategories")]
        public async Task<IActionResult> GetAllSubcategoriesAsync()
        {
            try
            {
                var subcategories = await _subcategoryService.GetAllSubcategoriesAsync();
                if (subcategories == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No subcategories found");
                }
                var subcategoriesDTO = _mapper.Map<List<SubcategoryReadDto>>(subcategories);
                return StatusCode(StatusCodes.Status200OK, subcategoriesDTO);
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
        /// Get subcategory by Id
        /// </summary>
        /// <param name="Id"> Subcategory Id</param>
        /// <returns> Ok response with subcategory details</returns>
        [HttpGet, Route("subcategory/{Id}")]
        public async Task<IActionResult> GetSubcategoryByIdAsync(int Id)
        {
            try
            {
                var subcategory = await _subcategoryService.GetSubcategoryByIdAsync(Id);
                if (subcategory == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Subcategory with Id {Id} not found");
                }
                var subcategoryDTO = _mapper.Map<SubcategoryReadDto>(subcategory);
                return StatusCode(StatusCodes.Status200OK, subcategoryDTO);
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
        /// Add subcategory
        /// </summary>
        /// <param name="subcategory"> Subcategory data transfer object</param>
        /// <returns> Ok response with added subcategory details</returns>
        [HttpPost, Route("subcategory")]
        public async Task<IActionResult> AddSubcategoryAsync([FromBody] SubcategoryAdd_UpdateDto subcategory)
        {
           if (subcategory == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Subcategory data is missing");
            }

           if(!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Invalid data");
            }

            try
            {
                var subcategoryEntity = _mapper.Map<Subcategory>(subcategory);
                var addedSubcategory = await _subcategoryService.AddSubcategoryAsync(subcategoryEntity);
                var subcategoryDTO = _mapper.Map<SubcategoryReadDto>(addedSubcategory);
                return StatusCode(StatusCodes.Status201Created, subcategoryDTO);
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
        /// Update subcategory
        /// </summary>
        /// <param name="Id"> Subcategory Id</param>
        /// <param name="subcategoryUpdateDto"> Subcategory data transfer object</param>
        /// <returns></returns>
        [HttpPut, Route("subcategory/{Id}")]
        public async Task<IActionResult> UpdateSubcategoryAsync(int Id, [FromBody] SubcategoryAdd_UpdateDto subcategoryUpdateDto)
        {
            if (subcategoryUpdateDto == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Subcategory data is missing");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Invalid data");
            }

            try
            {
                var subcategory= await _subcategoryService.GetSubcategoryByIdAsync(Id);
                if(subcategory == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Subcategory with Id {Id} not found");
                }
                _mapper.Map(subcategoryUpdateDto, subcategory);
                var updatedSubcategory = await _subcategoryService.UpdateSubcategoryAsync(subcategory);

                if(updatedSubcategory == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Couldn't update subcategory");
                }
                var subcategoryDTO = _mapper.Map<SubcategoryReadDto>(updatedSubcategory);

                return StatusCode(StatusCodes.Status200OK, subcategoryDTO);

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
        /// Delete subcategory
        /// </summary>
        /// <param name="Id"> Subcategory Id</param>
        /// <returns> Ok response with deleted subcategory details</returns>
        [HttpDelete, Route("subcategory/{Id}")]
        public async Task<IActionResult> DeleteSubcategoryAsync(int Id)
        {
            try
            {
                var subcategory = await _subcategoryService.GetSubcategoryByIdAsync(Id);
                if (subcategory == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Subcategory with Id {Id} not found");
                }
                var deletedSubcategory = await _subcategoryService.DeleteSubcategoryAsync(Id);
                if (deletedSubcategory == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Couldn't delete subcategory with Id {Id}");
                }
                var subcategoryDTO = _mapper.Map<SubcategoryReadDto>(deletedSubcategory);
                return StatusCode(StatusCodes.Status200OK, subcategoryDTO);
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
