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
    public class BrandsController : CustomBaseController
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandService.GetAllAsync();
            var brandsDto = _mapper.Map<List<BrandDto>>(brands.ToList());
            return CreateActionResultInstance(Response<IList<BrandDto>>.Success(brandsDto,200));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(BrandDto brandDto)
        {
            var brands = await _brandService.AddAsync(_mapper.Map<Brand>(brandDto));
            var brandDtos = _mapper.Map<BrandDto>(brands);
            return CreateActionResultInstance(Response<BrandDto>.Success(brandDtos, 201));
        }
    }
}
