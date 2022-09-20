using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Entities.Concrete
{
    public class Image
    {
        public int Id { get; set; }
        public string ImagesUrl { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
    }
}
