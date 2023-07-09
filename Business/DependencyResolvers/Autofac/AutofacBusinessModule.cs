using Autofac;
using Business.Abstract;
using Business.concrete;
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

        }
    }
}
