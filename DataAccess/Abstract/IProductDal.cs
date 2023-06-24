using Core.DataAcces;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{        
    public interface IProductDal : IEntityRepository<Product>
    {
        // interface kendisi public değildir fakat metodları default publictir
        // senbir IEntityRepositorysin ve calisma tipin Productur
        // you are a IEntityRepositorysin and your type is a Product


    }
}
