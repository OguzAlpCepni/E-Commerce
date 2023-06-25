using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.EntitiyFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Product, NorthwindContext>, ICategoryDal
    {
        
    }
}
