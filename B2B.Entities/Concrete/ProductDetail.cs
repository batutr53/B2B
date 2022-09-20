using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Entities.Concrete
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public string? CC { get; set; }
        public string? MaksSpeed { get; set; }
        public int? Kg { get; set; }
        public int? Hp { get; set; }
        public string? Type { get; set; }
        public string? Year  { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
