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
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
           //builder.HasMany(b => b.ProductImages).WithOne(b => b.Image).HasForeignKey(b => b.ImageId);
            builder.Property(x => x.ImagesUrl).IsRequired();
        }
    }
}
