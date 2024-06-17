using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dependency_Interfaces
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllBrandsAsync();
        Task<Brand> GetBrandByIdAsync(int id);
        Task<Brand> AddBrandAsync(Brand brand);
        Task<Brand> UpdateBrandAsync(Brand brand);
        Task<Brand> DeleteBrandAsync(int id);
    }
}
