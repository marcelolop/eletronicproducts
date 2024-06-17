using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.Entities;

namespace Entities.Dependency_Interfaces
{
    public interface IProductSystemContext
    {
        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;

        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Subcategory> Subcategories { get; set; }
    }
}
