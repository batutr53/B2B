using B2B.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccess.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly B2BDbContext _context;

        public UnitOfWork(B2BDbContext context)
        {
            _context = context;
        }

        public IProductRepository Product => new ProductRepository(_context);
        public ICategoryRepository Category => new CategoryRepository(_context);
        public IImageRepository Image => new ImageRepository(_context);
        public IBrandRepository Brand => new BrandRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
