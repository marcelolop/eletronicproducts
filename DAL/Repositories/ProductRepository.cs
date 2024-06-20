using DAL.Dependency_Interfaces;
using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dependency_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProductRepository :GenericCRUDRepository<Product> , IProductRepository
    {
        private readonly IProductSystemContext _context;

        public ProductRepository(IProductSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByDetailsAsync(int categoryId,int subcategoryId,int productId)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.CategoryId == categoryId && p.SubcategoryId == subcategoryId && p.ProductId == productId);
                if (product == null)
                {
                    throw new InvalidOperationException("Product not found");
                }
                return product;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get product: {ex.Message}");
            }
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            try
            {
                var products = await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
                if (products == null || !products.Any())
                {
                    throw new InvalidOperationException("No products found for category ID");
                }
                return products;

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
                var products = await _context.Products.Where(p => p.CategoryId == categoryId && p.SubcategoryId == subcategoryId).ToListAsync();
                if (products == null || !products.Any())
                {
                    throw new InvalidOperationException("No products found for category ID and subcategory ID");
                }
                return products;
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
                var products = await _context.Products.Where(p => p.BrandId == brandId).ToListAsync();
                if (products == null || !products.Any())
                {
                    throw new InvalidOperationException("No products found for brand ID");
                }
                return products;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get products: {ex.Message}");
            }
        }
    }
}
