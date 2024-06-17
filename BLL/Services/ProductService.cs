using BLL.Dependency_Interfaces;
using DAL.Dependency_Interfaces;
using Entities.Models.Entities;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        //Dependency Injection
        private readonly IGenericCRUDRepository<Product> _productRepository;

        public ProductService(IGenericCRUDRepository<Product> productRepository)
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

    }
}
