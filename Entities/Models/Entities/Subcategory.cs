using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Entities
{
    public class Subcategory
    {
        private int subcategoryId;
        private string name;
        private int categoryId;
        private Category category;

        [Key]
        public int SubcategoryId { 
            get => subcategoryId;
            set => subcategoryId = value;
        }

        [Required]
        [StringLength(100)]
        public string Name {
            get => name;
            set => name = value;
        }

        [ForeignKey("Category")]
        public int CategoryId {
            get => categoryId;
            set => categoryId = value;
        }

        public virtual Category Category {
            get => category;
            set => category = value;
        }

    }
}
