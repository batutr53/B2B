using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator,object entity) {

            var result = validator.Validate((IValidationContext)entity);
            if (!result.IsValid) {

                throw new ValidationException(result.Errors);
            }
        }
    }
}
