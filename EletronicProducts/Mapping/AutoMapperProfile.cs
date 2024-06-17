using AutoMapper;
using Entities.Models.Entities;
using Entities.Models.DTOs.CategoryDTOs;
using Entities.Models.DTOs.ProductsDTOs;
using Entities.Models.DTOs.SubcategoryDTOs;
using Entities.Models.DTOs.BrandDTOs;

namespace EletronicProducts.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<Category, CategoryReadDto>();
            CreateMap<Subcategory, SubcategoryReadDto>();
            CreateMap<Brand, BrandReadDto>();

            CreateMap<ProductAdd_UpdateDto, Product>();
            CreateMap<CategoryAdd_UpdateDto, Category>();
            CreateMap<SubcategoryAdd_UpdateDto, Subcategory>();
            CreateMap<BrandAdd_UpdateDto, Brand>();


        }
    }
}
