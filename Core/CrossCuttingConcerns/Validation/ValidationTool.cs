using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator)
        {
            var context = new ValidationContext<Product>(product);                  // product için doğrulama işlemi yapıcam 
            ProductValidator productValidator = new ProductValidator();             //benim kurallarım için 
            var result =  productValidator.Validate(context);           
            if (!result.IsValid)                                                    // geçerli değilse hata fırlat 
            {
                throw new ValidationException(result.Errors);
            }
            
        }
    }
}
