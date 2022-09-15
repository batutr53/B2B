using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Entities.Dtos
{
    public class ProductGetAllListDto:ProductDto
    {
        public BrandDto Brand { get; set; }
        public CategoryDto Category { get; set; }
        public ModelDto Model { get; set; }
        public List<ProductImageDto> Images { get; set; }
        public ProductDetailDto ProductDetail { get; set; }
    }
}
