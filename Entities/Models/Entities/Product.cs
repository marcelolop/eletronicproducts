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
        private int quantity;
        private int categoryId;
        private Category category;
        private int subcategoryId;
        private Subcategory subcategory;
        private int brandId;
        private Brand brand; 
        private string imageUrl;
        private int reviewsCount;
        private double rating;

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

        [Required]
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
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

        [ForeignKey("Subcategory")]
        public int SubcategoryId
        {
            get => subcategoryId;
            set => subcategoryId = value;
        }

        public virtual Subcategory Subcategory
        {
            get => subcategory;
            set => subcategory = value;
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

        public int ReviewsCount
        {
            get => reviewsCount;
            set => reviewsCount = value;
        }

        public double Rating
        {
            get => rating;
            set => rating = value;
        }
    }
}
