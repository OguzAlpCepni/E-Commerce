using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.concrete.EntitiyFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
            // Program.cs de yazmış olduğun referans işlemlerini gerçekleştirir 
        protected override void Load(ContainerBuilder builder)
        {
            // senden IProductService istersem productManager instance ver
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            //builder.RegisterType<IHttpContextAccessor>().As<IHttpContextAccessor>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
//Autofac kullanmamızın sebebi .Net mimarisindede var evet ama  aynı zamanda interceptor çalışan uygulama içerisinde
//(GetExecutingAssembly();) implemente edilmiş interfaceleri bul (AsImplementedInterfaces()) onlar için AspectInterceptorSelector()
//cagir 
// kısaca  bütün sınıflarım için önce AspectInterceptorSelector() bunu çalıştırıyor git bu classın bir aspecti var mı ([] olanla)
// 