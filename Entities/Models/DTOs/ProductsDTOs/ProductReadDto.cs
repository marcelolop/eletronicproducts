using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTOs.ProductsDTOs
{
    public class ProductReadDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public string ImageUrl { get; set; }

        public int ReviewsCount { get; set; }
        public double Rating { get; set; }
    }
}
