using B2B.Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetProductWithCategory(int categoryId)
        {
            var response = await _productService.GetProductWithCategory(categoryId);
            return CreateActionResultInstance(response);


            if (ModelState.IsValid)
            {

            }
        }
    }
}
