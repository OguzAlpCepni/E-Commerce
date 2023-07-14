using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.concrete.EntitiyFramework;
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