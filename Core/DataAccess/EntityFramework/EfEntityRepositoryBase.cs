using Core.DataAcces;
using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity>
        where TEntity : class,IEntity, new()
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {                                                                               //IDisposable pattern  implementation of c#
            using (TContext context = new TContext())                     // bir classı newlediğinde o bellekten garbage collector belli bir zamanda düzenli olarak gelir ve bellekten onu atar  using içerisine yazdığınız nesneler  using bitiminde garbage collectore diyprki beni bellekten at çünkü context nesne biraz masraflı 
            {
                var addedEntity = context.Entry(entity);                                // git veri kaynağından  benim gönderdiğim productan bir tanesi eşleştir 
                addedEntity.State = EntityState.Added;
                context.SaveChanges();                                                  // kısaca 1. satır referansı yakala 2) o aslında eklenecek bir nesne 3) ekle ve kaydet 
            }                                                                           // garbage collector topla 
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())                     // bir classı newlediğinde o bellekten garbage collector belli bir zamanda düzenli olarak gelir ve bellekten onu atar  using içerisine yazdığınız nesneler  using bitiminde garbage collectore diyprki beni bellekten at çünkü context nesne biraz masraflı 
            {
                var deletedEntity = context.Entry(entity);                              // git veri kaynağından  benim gönderdiğim productan bir tanesi eşleştir 
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // contex.Set<Product>() -----> bu benim ürünler tablom 
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();               // SELECT * FROM PRODUCTS
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())                     // bir classı newlediğinde o bellekten garbage collector belli bir zamanda düzenli olarak gelir ve bellekten onu atar  using içerisine yazdığınız nesneler  using bitiminde garbage collectore diyprki beni bellekten at çünkü context nesne biraz masraflı 
            {
                var updateEntity = context.Entry(entity);                               // git veri kaynağından  benim gönderdiğim productan bir tanesi eşleştir 
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();                                                  // kısaca 1. satır referansı yakala 2) o aslında eklenecek bir nesne 3) ekle ve kaydet 
            }
        }
    }
}
