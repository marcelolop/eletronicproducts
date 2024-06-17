using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dependency_Interfaces
{
    public interface ISubcategoryService
    {
        Task<List<Subcategory>> GetAllSubcategoriesAsync();
        Task<Subcategory> GetSubcategoryByIdAsync(int id);
        Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory);
        Task<Subcategory> UpdateSubcategoryAsync(Subcategory subcategory);
        Task<Subcategory> DeleteSubcategoryAsync(int id);
    }
}
