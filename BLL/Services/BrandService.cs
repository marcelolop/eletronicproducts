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
    public class BrandService : IBrandService
    {
        private readonly IGenericCRUDRepository<Brand> _brandRepository;

        public BrandService(IGenericCRUDRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<List<Brand>> GetAllBrandsAsync()
        {
            try
            {
                return await _brandRepository.GetAllEntitiesAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get brands: {ex.Message}");
            }
        }

        public async Task<Brand> GetBrandByIdAsync(int id)
        {
            try
            {
                return await _brandRepository.GetEntityByIdAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get brand: {ex.Message}");
            }
        }

        public async Task<Brand> AddBrandAsync(Brand brand)
        {
            try
            {
                return await _brandRepository.AddEntityAsync(brand);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't create brand: {ex.Message}");
            }
        }

        public async Task<Brand> UpdateBrandAsync(Brand brand)
        {
            try
            {
                return await _brandRepository.UpdateEntityAsync(brand);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't update brand: {ex.Message}");
            }
        }

        public async Task<Brand> DeleteBrandAsync(int id)
        {
            try
            {
                return await _brandRepository.DeleteEntityAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't delete brand: {ex.Message}");
            }
        }

    }
}
