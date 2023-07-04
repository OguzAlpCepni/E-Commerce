using Business.Abstract;
using Business.concrete;
using DataAccess.Abstract;
using DataAccess.concrete.EntitiyFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Autofac,Ninject,castleWindsor,Structuremap,LightInject,dryInject -->IOC container
            builder.Services.AddControllers();
            builder.Services.AddSingleton<IProductService,ProductManager>(); 
            builder.Services.AddSingleton<IProductDal,EfProductDal>();
            // bana arka planda bir referans olu�tur birisi senden IproductsServices isterse ona bir ProductManager olu�tur ve onu ver yani 
            // eger sen bir ba��ml�l�k g�r�rsen ona ikinci referans� ver 
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}