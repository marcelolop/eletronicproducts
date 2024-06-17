using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTOs.CategoryDTOs
{
    public class CategoryAdd_UpdateDto
    {
        public string Name { get; set; }
        public List<int> SubcategoryIds { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
