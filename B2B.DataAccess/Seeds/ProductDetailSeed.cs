using B2B.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccess.Seeds
{
    public class ProductDetailSeed : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasData(
                new ProductDetail
                {
                    Id = 1,
                    Color = "Black",
                    ProductId = 1,
                },
                new ProductDetail
                {
                    Id = 2,
                    Color = "Red",
                    ProductId=2
                    
                });
        }
    }
}
