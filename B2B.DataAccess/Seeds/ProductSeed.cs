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
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product 
                {
                    Id = 1,
                    Name = "Bajaj Pulsar Rs 200 2022",
                    Price = 73505,
                    Description = "HIZ TUTKUNUZUN YENİ PARTNERİ Tutkunuzu hızlandıracak,hız tutkunuza partner olacak Pulsar RS 200 ile tanışın.RS 200 ile yolculuklarınız hızlanacak, tutkunuz aşka dönüşecek.Pulsar RS 200 Hız tutkunuzun yeni partneri",
                    CategoryId = 1,
                    BrandId = 1,
                    ModelId = 1,
                },
                new Product
                {
                    Id=2,
                    Name = "Bajaj Pulsar Dominar Tur 400",
                    Price = 118000,
                    Description = "Dominar 400'ün 29.4kW güç ve 35 Nm tork üretebilen canavar gücündeki motoru ile yol maceranıza hazırlanın ve yola koyulun.",
                    CategoryId =1,
                    BrandId = 1,
                    ModelId = 2,

                    
                }
                );
        }
    }
}
