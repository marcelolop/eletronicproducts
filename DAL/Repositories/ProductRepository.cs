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
    public class ProductRepository :GenericCRUDRepository<Product>
    {
        private readonly IProductSystemContext _context;


        public ProductRepository(IProductSystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
