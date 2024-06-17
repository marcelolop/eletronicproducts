using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTOs.SubcategoryDTOs
{
    public class SubcategoryReadDto
    {
        public int SubcategoryId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
