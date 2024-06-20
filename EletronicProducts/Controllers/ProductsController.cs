using AutoMapper;
using BLL.Dependency_Interfaces;
using Microsoft.AspNetCore.Http;
using Entities.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Entities.Models.DTOs.ProductsDTOs;

namespace EletronicProducts.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Dependency Injection
        private IMapper _mapper;
        private IProductService _productService;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns> List of all products</returns>
        [HttpGet, Route("products")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                if (products == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No products found");
                }
                var productsDTO = _mapper.Map<List<ProductReadDto>>(products);
                return StatusCode(StatusCodes.Status200OK, productsDTO);
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
        /// Get product by Id
        /// </summary>
        /// <param name="Id"> Product Id</param>
        /// <returns> Ok response with product details</returns>
        [HttpGet, Route("products/{Id}")]
        public async Task<IActionResult> GetProductByIdAsync(int Id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(Id);
                if (product == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Product with ID: {Id} not found");
                }
                var productDTO = _mapper.Map<ProductReadDto>(product);
                return StatusCode(StatusCodes.Status200OK, productDTO);
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
        /// Get all products by category Id
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <returns>Ok response with list of products</returns>
        [HttpGet, Route("products/category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryAsync(int categoryId)
        {
            try
            {
                var products = await _productService.GetProductsByCategoryAsync(categoryId);
                if (products == null || !products.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"No products found for category ID: {categoryId}");
                }
                var productsDTO = _mapper.Map<IEnumerable<ProductReadDto>>(products);
                return StatusCode(StatusCodes.Status200OK, productsDTO);
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
        /// Get all products by category and subcategory Id
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="subcategoryId">Subcategory Id</param>
        /// <returns>Ok response with list of products</returns>
        [HttpGet, Route("products/category/{categoryId}/subcategory/{subcategoryId}")]
        public async Task<IActionResult> GetProductsByCategoryAndSubcategoryAsync(int categoryId, int subcategoryId)
        {
            try
            {
                var products = await _productService.GetProductsByCategoryAndSubcategoryAsync(categoryId, subcategoryId);
                if (products == null || !products.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"No products found for category ID: {categoryId} and subcategory ID: {subcategoryId}");
                }
                var productsDTO = _mapper.Map<IEnumerable<ProductReadDto>>(products);
                return StatusCode(StatusCodes.Status200OK, productsDTO);
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
        /// Get all products by brand Id
        /// </summary>
        /// <param name="brandId">Brand Id</param>
        /// <returns>Ok response with list of products</returns>
        [HttpGet, Route("products/brand/{brandId}")]
        public async Task<IActionResult> GetProductsByBrandAsync(int brandId)
        {
            try
            {
                var products = await _productService.GetProductsByBrandAsync(brandId);
                if (products == null || !products.Any())
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"No products found for brand ID: {brandId}");
                }
                var productsDTO = _mapper.Map<IEnumerable<ProductReadDto>>(products);
                return StatusCode(StatusCodes.Status200OK, productsDTO);
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
        /// Get product details by category, subcategory and product Id
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="subcategoryId">Subcategory Id</param>
        /// <param name="productId">Product Id</param>
        /// <returns> Ok response with product details</returns>
        [HttpGet, Route("products/{categoryId}/{subcategoryId}/{productId}")]
        public async Task<IActionResult> GetProductDetailsAsync(int categoryId, int subcategoryId, int productId)
        {
            try
            {
                var product = await _productService.GetProductByDetailsAsync(categoryId, subcategoryId, productId);
                if (product == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Product with Category ID: {categoryId}, Subcategory ID: {subcategoryId} and Product ID: {productId} not found");
                }
                var productDTO = _mapper.Map<ProductReadDto>(product);
                return StatusCode(StatusCodes.Status200OK, productDTO);
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
        /// Add a new product
        /// </summary>
        /// <param name="productCreateDTO"> Product data transfer object</param>
        /// <returns> Ok response if product is added successfully</returns>
        [HttpPost, Route("products")]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductAdd_UpdateDto productCreateDTO)
        {
            if (productCreateDTO == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "ProductCreateDTO is null");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                var product = _mapper.Map<Product>(productCreateDTO);
                var newProduct = await _productService.AddProductAsync(product);
                var productDTO = _mapper.Map<ProductReadDto>(newProduct);
                return StatusCode(StatusCodes.Status201Created, productDTO);
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
        /// Update product details
        /// </summary>
        /// <param name="Id"> Product Id</param>
        /// <param name="productUpdateDTO"> Data transfer object with updated product details</param>
        /// <returns> Ok response if product is updated successfully</returns>
        [HttpPut, Route("products/{Id}")]
        public async Task<IActionResult> UpdateProductAsync(int Id, [FromBody] ProductAdd_UpdateDto productUpdateDTO)
        {
            if (productUpdateDTO == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "ProductUpdateDTO is null");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            try
            {
                var product = await _productService.GetProductByIdAsync(Id);
                if (product == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Product with ID: {Id} not found");
                }

                _mapper.Map(productUpdateDTO, product);
                var updatedProduct = await _productService.UpdateProductAsync(product);

                if (updatedProduct == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Couldn't update entity with ID: {Id}");
                }
                var productDTO = _mapper.Map<ProductReadDto>(updatedProduct);

                return StatusCode(StatusCodes.Status200OK, productDTO);
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
        /// Delete a product
        /// </summary>
        /// <param name="Id"> Product Id</param>
        /// <returns> Ok response if product is deleted successfully</returns>
        [HttpDelete, Route("products/{Id}")]
        public async Task<IActionResult> DeleteProductAsync(int Id)
        {
            if (Id <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Invalid product ID");
            }

            try
            {
                var product = await _productService.GetProductByIdAsync(Id);
                if (product == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Product with ID: {Id} not found");
                }

                var deletedProduct = await _productService.DeleteProductAsync(Id);

                if (deletedProduct == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Couldn't delete entity with ID: {Id}");
                }

                var productDTO = _mapper.Map<ProductReadDto>(deletedProduct);
                return StatusCode(StatusCodes.Status200OK, productDTO);
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
