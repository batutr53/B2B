using B2B.Business.Services.Abstract;
using B2B.DataAccess.Repositories.Abstract;
using B2B.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Business.Services.Concrete
{
    public class ImageService : Services<Image>, IImageService
    {
        public ImageService(IGenericRepository<Image> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
