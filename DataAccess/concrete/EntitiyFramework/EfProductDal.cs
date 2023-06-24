using DataAccess.Abstract;
using Entities.concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.EntitiyFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {                                                                               //IDisposable pattern  implementation of c#
            using (NorthwindContext context = new NorthwindContext())                     // bir classı newlediğinde o bellekten garbage collector belli bir zamanda düzenli olarak gelir ve bellekten onu atar  using içerisine yazdığınız nesneler  using bitiminde garbage collectore diyprki beni bellekten at çünkü context nesne biraz masraflı 
            {
                var addedEntity = context.Entry(entity);                                // git veri kaynağından  benim gönderdiğim productan bir tanesi eşleştir 
                addedEntity.State=EntityState.Added;
                context.SaveChanges();                                                  // kısaca 1. satır referansı yakala 2) o aslında eklenecek bir nesne 3) ekle ve kaydet 
            }                                                                           // garbage collector topla 
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())                     // bir classı newlediğinde o bellekten garbage collector belli bir zamanda düzenli olarak gelir ve bellekten onu atar  using içerisine yazdığınız nesneler  using bitiminde garbage collectore diyprki beni bellekten at çünkü context nesne biraz masraflı 
            {
                var deletedEntity = context.Entry(entity);                              // git veri kaynağından  benim gönderdiğim productan bir tanesi eşleştir 
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); // contex.Set<Product>() -----> bu benim ürünler tablom 
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();               // SELECT * FROM PRODUCTS
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())                     // bir classı newlediğinde o bellekten garbage collector belli bir zamanda düzenli olarak gelir ve bellekten onu atar  using içerisine yazdığınız nesneler  using bitiminde garbage collectore diyprki beni bellekten at çünkü context nesne biraz masraflı 
            {
                var updateEntity = context.Entry(entity);                               // git veri kaynağından  benim gönderdiğim productan bir tanesi eşleştir 
                updateEntity.State = EntityState.Modified;  
                context.SaveChanges();                                                  // kısaca 1. satır referansı yakala 2) o aslında eklenecek bir nesne 3) ekle ve kaydet 
            }
        }
    }
}
