using BLL.Dependency_Interfaces;
using DAL.Dependency_Interfaces;
using Entities.Models.Entities;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        //Dependency Injection
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _productRepository.GetAllEntitiesAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get products: {ex.Message}");
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productRepository.GetEntityByIdAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get product: {ex.Message}");
            }
        }

        public async Task<Product> GetProductByDetailsAsync(int categoryId, int subcategoryId,int productId)
        {
            try
            {
                return await _productRepository.GetProductByDetailsAsync(categoryId, subcategoryId, productId);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get product: {ex.Message}");
            }
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                return await _productRepository.AddEntityAsync(product);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't create product: {ex.Message}");
            }
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                return await _productRepository.UpdateEntityAsync(product);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't update product: {ex.Message}");
            }
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            try
            {
                return await _productRepository.DeleteEntityAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't delete product: {ex.Message}");
            }
        }

        

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            try
            {
                return await _productRepository.GetProductsByCategoryAsync(categoryId);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get products: {ex.Message}");
            }
        }


        public async Task<List<Product>> GetProductsByCategoryAndSubcategoryAsync(int categoryId, int subcategoryId)
        {
            try
            {
                return await _productRepository.GetProductsByCategoryAndSubcategoryAsync(categoryId, subcategoryId);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get products: {ex.Message}");
            }
        }

        public async Task<List<Product>> GetProductsByBrandAsync(int brandId)
        {
            try
            {
                return await _productRepository.GetProductsByBrandAsync(brandId);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get products: {ex.Message}");
            }
        }

    }
}
