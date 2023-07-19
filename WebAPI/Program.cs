using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.concrete;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.concrete.EntitiyFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;

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
            //builder.Services.AddSingleton<IProductService,ProductManager>(); 
            //builder.Services.AddSingleton<IProductDal,EfProductDal>();
            // bana arka planda bir referans oluþtur birisi senden IproductsServices isterse ona bir ProductManager oluþtur ve onu ver yani 
            // eger sen bir baðýmlýlýk görürsen ona ikinci referansý ver 
            
            // IOC alt yapýn var ama autofaci kullan 
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });
            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}