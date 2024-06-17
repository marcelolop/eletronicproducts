using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.DTOs.ProductsDTOs;

namespace Entities.Models.DTOs.BrandDTOs
{
    public class BrandAdd_UpdateDto
    {
        public string BrandName { get; set; }

        public string Logo { get; set; }

        public List<ProductReadDto> Products { get; set; }
    }
}
