using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.EntitiyFramework
{
    internal class EfOrderDal : EfEntityRepositoryBase<Order,NorthwindContext> , IOrderDal
    {
    }
}
