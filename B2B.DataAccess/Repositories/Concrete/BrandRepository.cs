using B2B.DataAccess.Repositories.Abstract;
using B2B.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccess.Repositories.Concrete
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly B2BDbContext _dbContext;
        public BrandRepository(B2BDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
