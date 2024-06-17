using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Entities
{
    public class Product
    {
        private int productId;
        private string name;
        private string description;
        private decimal price;
        private int categoryId;
        private Category category;
        private int brandId; // Nova chave estrangeira
        private Brand brand; // Nova propriedade de navegação
        private string imageUrl;

        [Key]
        public int ProductId
        {
            get => productId;
            set => productId = value;
        }

        [Required]
        [StringLength(100)]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [StringLength(500)]
        public string Description
        {
            get => description;
            set => description = value;
        }

        [DataType(DataType.Currency)]
        public decimal Price
        {
            get => price;
            set => price = value;
        }

        [ForeignKey("Category")]
        public int CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        public virtual Category Category
        {
            get => category;
            set => category = value;
        }

        [ForeignKey("Brand")]
        public int BrandId
        {
            get => brandId;
            set => brandId = value;
        }

        public virtual Brand Brand
        {
            get => brand;
            set => brand = value;
        }

        [StringLength(500)]
        public string ImageUrl
        {
            get => imageUrl;
            set => imageUrl = value;
        }
    }
}
