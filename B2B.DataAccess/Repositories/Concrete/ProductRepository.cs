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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
         private readonly B2BDbContext _dbContext;
        public ProductRepository(B2BDbContext context) : base(context)
        {
           _dbContext = context;
        }

        public async Task<List<Product>> GetList()
        {
            return await _dbContext.Products
                .Include(c => c.Category)
                .Include(b => b.Brand)
                .Include(m => m.Model)
                .Include(p => p.ProductDetail)
                .Include(pi => pi.ProductImages).ThenInclude(i=>i.Image).AsNoTracking().ToListAsync();
        }

        public Product GetName(string name)
        {
            return _dbContext.Products.Where(a=>a.Name == name).FirstOrDefault();
        }

        public async Task<List<Product>> GetProductWithCategory(int categoryId)
        {
            return await _dbContext.Products
                .Include(x => x.Category).Where(x=>x.CategoryId == categoryId).AsNoTracking().ToListAsync();
        }
    }
}
