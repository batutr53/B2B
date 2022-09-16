using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccess.Repositories.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IImageRepository Image { get; }
        IBrandRepository Brand { get; }
        Task SaveAsync();
        void Save();
    }
}
