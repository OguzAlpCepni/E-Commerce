using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("this is not a validator class");
            }   

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);                       // reflection :çalışma anında bir şeyleri çalışmamızı sağlıyor newleme işlemini çalışma anında yapıyoruz .ProductValidatorun bir instancesini oluştur 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];                          //ProductHeaderValue validatorun generic  çalışma tipini bul 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);                  //  parametrelerini bul ilgili metodun yani add(Product product). Metodun parametrelerinr bak validatorun tipine eşit olna tipleri bul
            foreach (var entity in entities)                                                            //invocation metod demek // herbirini tek tek gez 
            {
                ValidationTool.Validate(validator, entity);                                             // validation toolsu kullanarak  validate et
            }
        }
    }
}
