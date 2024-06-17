using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Entities
{
    public class Brand
    {
        private int brandId;
        private string brandName;
        private string logo;
        private List<Product> products;

        [Key]
        public int BrandId
        {
            get => brandId;
            set => brandId = value;
        }

        [Required]
        [StringLength(100)]
        public string BrandName
        {
            get => brandName;
            set => brandName = value;
        }

        [StringLength(500)]
        public string Logo
        {
            get => logo;
            set => logo = value;
        }

        public virtual List<Product> Products
        {
            get => products;
            set => products = value;
        }
    }
}