using Entities.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//Generic constraint
namespace DataAccess.Abstract
{                                                                                       // bu kısımda biz T'Yi düzneliyoruz T referans tip olabilir.Ayrıca T IEntity yada IEntityden implement olan bir şey olabilir .New ile ise newlenebilir olmalı 
    public interface IEntityRepository<T>where T:class,IEntity,new()                       //p=>p.CategoryId==2 gibi filtrelet yazmak için
    {                                                                                   //Linq kullanmak için bu ifadeyi yazıyoruz
        List<T> GetAll(Expression<Func<T,bool>> filter=null);                           // bir bankacılık uygulamasında hesapların liste şeklinde gelmesini sağlar
        T Get(Expression<Func<T, bool>> filter);                                        // ordan bir hesaba tıklayarak o hesabın detaylarına erişmek için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllByCategory(int categoryId);                                     // yukardaki ifadeyi yazarak bu ifadeyi yazmamıza gerek kalmadı 
    }
}
