using AutoMapper;
using B2B.Entities.Concrete;
using B2B.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Business.Mapping
{
    public class MapProfile : Profile
    {              //.ForMember(x => x.Images, o => o.MapFrom(a => a.ProductImages.Select(x => x.ProductId).ToList()));
                   //ForMember(i=>i.Images,opt=>opt.MapFrom(src=>src.ProductImages.Select(a=>a.Id).ToList()));
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductGetAllListDto>().ForMember(s => s.Images,x=>x.MapFrom(a=>a.ProductImages));
            CreateMap<Product, ProductWithCategoryDto>().ForMember(x=>x.CategoryId,o=>o.MapFrom(s=>s.Category.Id));
            CreateMap<Category, ProductWithCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailDto>().ReverseMap();
        }
    }
}
