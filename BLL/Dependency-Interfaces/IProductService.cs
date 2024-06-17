using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dependency_Interfaces
{
    public interface IProductService
    {

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns> List of all products</returns>
        Task<List<Product>> GetAllProductsAsync();

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"> Product Id</param>
        /// <returns> Product entity</returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="product"> Product entity</param>
        /// <returns> Product entity</returns>
        Task<Product> AddProductAsync(Product product);

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product"> Product entity</param>
        /// <returns> Product entity</returns>
        Task<Product> UpdateProductAsync(Product product);

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"> Product Id</param>
        /// <returns> Product entity</returns>
        Task<Product> DeleteProductAsync(int id);
    }
}
