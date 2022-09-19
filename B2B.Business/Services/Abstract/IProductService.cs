using B2B.Core.Utilities.Results;
using B2B.Entities.Concrete;
using B2B.Entities.Dtos;
using B2B.SharedTools.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Business.Services.Abstract
{
    public interface IProductService:IServices<Product>
    {
        Task<IResult> AddProduct(ProductCreateDto product);
        Task<Response<List<ProductGetAllListDto>>> GetProductList();
        Task<Response<List<ProductWithCategoryDto>>> GetProductWithCategory(int categoryId);
    }
}
