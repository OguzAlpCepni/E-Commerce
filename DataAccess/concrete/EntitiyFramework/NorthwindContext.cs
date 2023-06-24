using Entities.concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                                                                        //Context : Db dosyaları ile proje classlarını bağlamaya yarar
namespace DataAccess.concrete.EntitiyFramework
{                                                                                       // class ismini Context olarak yapmam bun calssın context olmasını sağlamaz 
                                                                                        // oyüzden Ef ile birlikte gelen base bir class olan DbContext kullanman lazım
    public class NorthwindContext:DbContext
    {
                                                                                        // projen hakkında hangi veri tabanı ile ilişki  olduğunu belirttiğimiz yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;Database=master;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }                                    //hangi classım hangi tabloya karşılık geliyor 
        public DbSet<Category> Categories { get; set; }                                 //hangi classım hangi tabloya karşılık geliyor 
        public DbSet<Customer> Customers { get; set; }                                  //hangi classım hangi tabloya karşılık geliyor 
    }
}
