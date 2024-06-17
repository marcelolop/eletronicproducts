using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTOs.CategoryDTOs
{
    public class CategoryReadDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<int> SubcategoryIds { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
