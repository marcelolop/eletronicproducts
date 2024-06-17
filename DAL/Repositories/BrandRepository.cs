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
    public class BrandRepository : GenericCRUDRepository<Brand>
    {
        private readonly IProductSystemContext _context;

        public BrandRepository(IProductSystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
