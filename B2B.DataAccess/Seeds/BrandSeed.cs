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
    public class BrandSeed : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Bajaj",
                },
                new Brand
                {
                    Id = 2,
                    Name = "Ducati",
                    
                },
                new Brand
                {
                    Id = 3,
                    Name = "Honda",
                }
                );
        }
    }
}
