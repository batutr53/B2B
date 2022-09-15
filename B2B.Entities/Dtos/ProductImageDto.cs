using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Entities.Dtos
{
    public class ProductImageDto
    {
        public int Id { get; set; }
        public string ImagesUrl { get; set; }
        public int ProductId { get; set; }
    }
}
