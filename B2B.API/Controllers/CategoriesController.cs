using AutoMapper;
using B2B.Business.Services.Abstract;
using B2B.Entities.Concrete;
using B2B.Entities.Dtos;
using B2B.SharedTools.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
       
            private readonly ICategoryService _categoryService;
            private readonly IMapper _mapper;

            public CategoriesController(ICategoryService categoryService, IMapper mapper)
            {
                _categoryService = categoryService;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var categories = await _categoryService.GetAllAsync();
                var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
                return CreateActionResultInstance(Response<IEnumerable<CategoryDto>>.Success(categoriesDto, 200));
            }
            [HttpPost]

            public async Task<IActionResult> Add(CategoryDto categoryDto) 
            {
            var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            var catDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResultInstance(Response<CategoryDto>.Success(204));
            }
        
    }
}
