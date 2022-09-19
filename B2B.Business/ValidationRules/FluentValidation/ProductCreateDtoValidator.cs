using B2B.Entities.Concrete;
using B2B.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Business.ValidationRules.FluentValidation
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(p => p.Name).Length(2, 150);
            RuleFor(p => p.Name).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(p=>p.Description).NotEmpty().Length(2,255);
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Price).GreaterThanOrEqualTo(1).WithMessage("1'den küçük olamaz");
        }
    }
}
