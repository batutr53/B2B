using B2B.DataAccess.Repositories.Abstract;
using B2B.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccess.Repositories.Concrete
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(B2BDbContext context) : base(context)
        {
        }
    }
}
