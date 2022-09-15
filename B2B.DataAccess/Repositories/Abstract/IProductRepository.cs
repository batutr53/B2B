using B2B.DataAccess.Repositories.Concrete;
using B2B.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccess.Repositories.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<List<Product>> GetList();
        Task<List<Product>> GetProductWithCategory(int categoryId);
    }
}
