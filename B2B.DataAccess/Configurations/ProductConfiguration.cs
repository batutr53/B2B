using B2B.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(b => b.ProductImages).WithOne(b => b.Product).HasForeignKey(b => b.ProductId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
