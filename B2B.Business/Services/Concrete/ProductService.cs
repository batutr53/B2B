using AutoMapper;
using B2B.Business.Services.Abstract;
using B2B.Business.ValidationRules.FluentValidation;
using B2B.Core.Aspects.Autofac.Caching;
using B2B.Core.Aspects.Autofac.Logging;
using B2B.Core.Aspects.Autofac.Performance;
using B2B.Core.Aspects.Autofac.Validation;
using B2B.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts.Loggers;
using B2B.DataAccess.Repositories.Abstract;
using B2B.Entities.Concrete;
using B2B.Entities.Dtos;
using B2B.SharedTools.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Business.Services.Concrete
{
    public class ProductService : Services<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 1)]
        [LogAspect(typeof(DatabaseLogger))]
        public async Task<Response<List<ProductGetAllListDto>>> GetProductList()
        {
            var products = await _productRepository.GetList();
            var productsDto = _mapper.Map<List<ProductGetAllListDto>>(products);
            return Response<List<ProductGetAllListDto>>.Success(productsDto, 200);
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheAspect(duration:1)]
        [LogAspect(typeof(FileLogger))]
        public async Task<Response<List<ProductWithCategoryDto>>> GetProductWithCategory(int categoryId)
        {
            var products = await _productRepository.GetProductWithCategory(categoryId);
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return Response<List<ProductWithCategoryDto>>.Success(productsDto,200);
        }

        //[CacheRemoveAspect("IProductService.Get")]
        //public async Task<Response<List<Product>>> Add(Product product)
        //{
        // //   var add = await _productRepository.AddAsync(_mapper.Map<Product>(product));
        //   // return Response<Product<>>.Success(add);
        //}
    }
}
