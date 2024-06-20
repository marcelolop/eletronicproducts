using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dependency_Interfaces
{
    public interface IProductRepository : IGenericCRUDRepository<Product>
    {
        Task<Product> GetProductByDetailsAsync(int categoryId, int subcategoryId, int productId);

        Task<List<Product>> GetProductsByCategoryAsync(int categoryId);

        Task<List<Product>> GetProductsByBrandAsync(int brandId);
        Task<List<Product>> GetProductsByCategoryAndSubcategoryAsync(int categoryId, int subcategoryId);
    }
}
