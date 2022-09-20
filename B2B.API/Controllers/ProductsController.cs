using AutoMapper;
using B2B.Business.Services.Abstract;
using B2B.Core.Aspects.Autofac.Caching;
using B2B.Entities.Concrete;
using B2B.Entities.Dtos;
using B2B.SharedTools.Dtos;
using B2B.SharedTools.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _productService;
       // private readonly ISharedIdentityService _sharedIdentityService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var response = await _productService.GetProductList();
            return CreateActionResultInstance(response);
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetProductWithCategory(int categoryId)
        {
            var response = await _productService.GetProductWithCategory(categoryId);
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductCreateDto productDto)
        {
           var product = await _productService.AddProduct(productDto);
            return Ok(product);
        }

        [HttpPut]
        public IActionResult Update(ProductUpdateDto productUpdate)
        {
            var product =  _productService.UpdateAsync(productUpdate);
            return Ok(product);
        }

    }
}
