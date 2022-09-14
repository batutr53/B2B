using B2B.DataAccess.Repositories.Abstract;
using B2B.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccess.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
         private readonly B2BDbContext _dbContext;
        public ProductRepository(B2BDbContext context) : base(context)
        {
           _dbContext = context;
        }

        public async Task<List<Product>> GetProductWithCategory(int categoryId)
        {
            return await _dbContext.Products
                .Include(x => x.Category).Where(x=>x.CategoryId == categoryId).AsNoTracking().ToListAsync();
        }
    }
}
