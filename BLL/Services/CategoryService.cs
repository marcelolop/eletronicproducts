using BLL.Dependency_Interfaces;
using DAL.Dependency_Interfaces;
using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericCRUDRepository<Category> _categoryRepository;

        public CategoryService(IGenericCRUDRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            try
            {
                return await _categoryRepository.GetAllEntitiesAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get categories: {ex.Message}");
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            try
            {
                return await _categoryRepository.GetEntityByIdAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get category: {ex.Message}");
            }
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            try
            {
                return await _categoryRepository.AddEntityAsync(category);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't create category: {ex.Message}");
            }
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            try
            {
                return await _categoryRepository.UpdateEntityAsync(category);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't update category: {ex.Message}");
            }
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            try
            {
                return await _categoryRepository.DeleteEntityAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't delete category: {ex.Message}");
            }
        }
    }
}
