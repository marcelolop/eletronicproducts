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
using Microsoft.Data.SqlClient;

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
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                    });
            });


            //Dependency Injection

            builder.Services.AddScoped<IProductSystemContext, ProductSystemContext>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IGenericCRUDRepository<Category>, CategoryRepository>();
            builder.Services.AddScoped<IGenericCRUDRepository<Subcategory>, SubcategoryRepository>();
            builder.Services.AddScoped<IGenericCRUDRepository<Brand>, BrandRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ISubcategoryService, SubcategoryService>();
            builder.Services.AddScoped<IBrandService, BrandService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            app.MapControllers();

            app.Run();
        }
    }
}
