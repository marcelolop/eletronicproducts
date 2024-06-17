using AutoMapper;
using BLL.Dependency_Interfaces;
using BLL.Services;
using DAL.Dependency_Interfaces;
using DAL.Repositories;
using EletronicProducts.Mapping;
using Entities.Context;
using Entities.Dependency_Interfaces;
using Entities.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EletronicProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // Register the Swagger generator, defining 1 or more Swagger documents
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            //AutoMapper Configuration
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);

            //Database Configuration
            builder.Services.AddDbContext<ProductSystemContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //Dependency Injection

            builder.Services.AddScoped<IProductSystemContext, ProductSystemContext>();

            builder.Services.AddScoped<IGenericCRUDRepository<Product>, ProductRepository>();
            builder.Services.AddScoped<IGenericCRUDRepository<Category>, CategoryRepository>();
            builder.Services.AddScoped<IGenericCRUDRepository<Subcategory>, SubcategoryRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ISubcategoryService, SubcategoryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
