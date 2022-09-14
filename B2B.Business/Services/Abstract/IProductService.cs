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
        Task<Response<List<ProductWithCategoryDto>>> GetProductWithCategory(int categoryId);
    }
}
