using AutoMapper;
using B2B.Business.Services.Abstract;
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

        public async Task<Response<List<ProductWithCategoryDto>>> GetProductWithCategory(int categoryId)
        {
            var products = await _productRepository.GetProductWithCategory(categoryId);
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return Response<List<ProductWithCategoryDto>>.Success(productsDto,200);
        }
    }
}
