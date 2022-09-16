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
    public class ImageSeed : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
                new Image
                {
                    Id = 1,
                    ImagesUrl = "https://www.ekuralkan.com/Data/EditorFiles/kuralkan/htlm_dosyalar/rs200/banner-rs200.jpg",
                    //ProductId = 1,
                   
                },
                new Image
                {
                    Id=2,
                    ImagesUrl = "https://www.ekuralkan.com/Data/EditorFiles/360/dominar%20D400%20EURO%205%20aksesuarl%C4%B1/k15.png",
                    //ProductId=2,
                    
                }
                ) ;

        }
    }
}
