using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models.Entities;
using Entities.Dependency_Interfaces;

namespace Entities.Context
{
    public class ProductSystemContext : DbContext, IProductSystemContext
    {
        public ProductSystemContext(DbContextOptions<ProductSystemContext> options) : base(options)
        {
        }

        /// <summary>
        /// Method to save changes asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Subcategory>().ToTable("Subcategory");
            modelBuilder.Entity<Brand>().ToTable("Brand");

            // Configurar a relação entre Produto e Categoria
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Evita a cascata de exclusão

            // Configurar a precisão do preço
            modelBuilder.Entity<Product>()
               .Property(p => p.Price)
               .HasPrecision(20, 5);

            // Configurar a relação entre Produto e Subcategoria
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Subcategory)
                .WithMany()
                .HasForeignKey(p => p.SubcategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Evita a cascata de exclusão

            // Configurar a relação entre Categoria e Subcategoria
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Subcategories)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Evita a cascata de exclusão

            // Configurar a relação entre Subcategoria e Categoria
            modelBuilder.Entity<Subcategory>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Evita a cascata de exclusão

            // Configurar a relação entre Produto e Marca
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.BrandId);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Method to get DbSet of type T
        /// </summary>
        /// <typeparam name="T"> Generic type</typeparam>
        /// <returns> DbSet of type T</returns>
        /// <exception cref="ArgumentException"> Throws exception if invalid type for DbSet</exception>
        public DbSet<T> Set<T>() where T : class
        {
            if (typeof(T) == typeof(Product))
            {
                return Products as DbSet<T>;
            }
            else if (typeof(T) == typeof(Category))
            {
                return Categories as DbSet<T>;
            }
            else if (typeof(T) == typeof(Subcategory))
            {
                return Subcategories as DbSet<T>;
            }
            else if (typeof(T) == typeof(Brand)) // Adicionar verificação para Brand
            {
                return Brands as DbSet<T>;
            }

            throw new ArgumentException("Invalid type for DbSet");
        }
    }
}
