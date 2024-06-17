using BLL.Dependency_Interfaces;
using DAL.Dependency_Interfaces;
using Entities.Models.DTOs.SubcategoryDTOs;
using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubcategoryService : ISubcategoryService 
    {
        private readonly IGenericCRUDRepository<Subcategory> _subcategoryRepository;

        public SubcategoryService(IGenericCRUDRepository<Subcategory> subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }


        public async Task<List<Subcategory>> GetAllSubcategoriesAsync()
        {
            try
            {
                return await _subcategoryRepository.GetAllEntitiesAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get subcategories: {ex.Message}");
            }
        }

        public async Task<Subcategory> GetSubcategoryByIdAsync(int id)
        {
            try
            {
                return await _subcategoryRepository.GetEntityByIdAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get subcategory: {ex.Message}");
            }
        }
        public async Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory)
        {
            try
            {
                return await _subcategoryRepository.AddEntityAsync(subcategory);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't create subcategory: {ex.Message}");
            }
        }

        public async Task<Subcategory> UpdateSubcategoryAsync(Subcategory subcategory)
        {
            try
            {
                return await _subcategoryRepository.UpdateEntityAsync(subcategory);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't update subcategory: {ex.Message}");
            }
        }

        public async Task<Subcategory> DeleteSubcategoryAsync(int id)
        {
            try
            {
                return await _subcategoryRepository.DeleteEntityAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't delete subcategory: {ex.Message}");
            }
        }
    }
}
