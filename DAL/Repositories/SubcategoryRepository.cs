using DAL.Dependency_Interfaces;
using Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dependency_Interfaces;

namespace DAL.Repositories
{
    public class SubcategoryRepository : GenericCRUDRepository<Subcategory>
    {
        private readonly IProductSystemContext _context;

        public SubcategoryRepository(IProductSystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
