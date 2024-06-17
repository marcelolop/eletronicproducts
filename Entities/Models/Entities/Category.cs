using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Entities
{

    public class Category
    {
        private int categoryId;
        private string name;
        private List<Subcategory> subcategories;
        private List<Product> products;


        [Key]
        public int CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        [Required]
        [StringLength(100)]
        public string Name { 
            get => name; 
            set => name = value; 
        }

        public virtual List<Subcategory> Subcategories {
            get => subcategories;
            set => subcategories = value;
        }

        public virtual List<Product> Products {
            get => products;
            set => products = value;
        }
    }
}
