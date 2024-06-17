using AutoMapper;
using BLL.Dependency_Interfaces;
using Microsoft.AspNetCore.Http;
using Entities.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Entities.Models.DTOs.BrandDTOs;

namespace EletronicProducts.Controllers
{
    [Route("api")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        //Dependency Injection
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all brands
        /// </summary>
        /// <returns> List of all brands</returns>
        [HttpGet, Route("brands")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
            try
            {
                var brands = await _brandService.GetAllBrandsAsync();
                if (brands == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No brands found");
                }
                var brandsDTO = _mapper.Map<List<BrandReadDto>>(brands);
                return StatusCode(StatusCodes.Status200OK, brandsDTO);
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
        /// Get brand by Id
        /// </summary>
        /// <param name="Id"> Brand Id</param>
        /// <returns> Ok response with brand details</returns>
        [HttpGet, Route("brand/{Id}")]
        public async Task<IActionResult> GetBrandByIdAsync(int Id)
        {
            try
            {
                var brand = await _brandService.GetBrandByIdAsync(Id);
                if (brand == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Brand not found");
                }
                var brandDTO = _mapper.Map<BrandReadDto>(brand);
                return StatusCode(StatusCodes.Status200OK, brandDTO);
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
        /// Add a new brand
        /// </summary>
        /// <param name="brandCreateDto"> Brand data transfer object</param>
        /// <returns> Ok response with brand details</returns>
        [HttpPost, Route("brand")]
        public async Task<IActionResult> AddBrandAsync([FromBody] BrandAdd_UpdateDto brandCreateDto)
        {
            if (brandCreateDto == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Brand data is missing");
            }

            if(!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            try
            {
                var brand = _mapper.Map<Brand>(brandCreateDto);
                var addedBrand = await _brandService.AddBrandAsync(brand);
                var brandDTO = _mapper.Map<BrandReadDto>(addedBrand);
                return StatusCode(StatusCodes.Status201Created, brandDTO);
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
        /// Update a brand
        /// </summary>
        /// <param name="Id"> Brand Id</param>
        /// <param name="brandUpdateDto"> Brand data transfer object</param>
        /// <returns> Ok response if brand is updated successfully</returns>
        [HttpPut, Route("brand/{Id}")]
        public async Task<IActionResult> UpdateBrandAsync(int Id, [FromBody] BrandAdd_UpdateDto brandUpdateDto)
        {
            if (brandUpdateDto == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Brand data is missing");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            try
            {
                var brand = await _brandService.GetBrandByIdAsync(Id);
                if (brand == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Brand with ID: {Id} not found");
                }
                _mapper.Map(brandUpdateDto, brand);
                var updatedBrand = await _brandService.UpdateBrandAsync(brand);

                if (updatedBrand == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Couldn't update brand with ID: {Id}");
                }

                var brandDTO = _mapper.Map<BrandReadDto>(updatedBrand);

                return StatusCode(StatusCodes.Status200OK, brandDTO);

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
        /// Delete a brand
        /// </summary>
        /// <param name="Id"> Brand Id</param>
        /// <returns> Ok response if brand is deleted successfully</returns>
        [HttpDelete, Route("brand/{Id}")]
        public async Task<IActionResult> DeleteBrandAsync(int Id)
        {
            if (Id <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Invalid ID");
            }

            try
            {
                var brand = await _brandService.GetBrandByIdAsync(Id);
                if (brand == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Brand with ID: {Id} not found");
                }
                var deletedBrand = await _brandService.DeleteBrandAsync(Id);
                if (deletedBrand == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Couldn't delete brand with ID: {Id}");
                }
                var brandDTO = _mapper.Map<BrandReadDto>(deletedBrand);
                return StatusCode(StatusCodes.Status200OK, brandDTO);
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
    }
}
