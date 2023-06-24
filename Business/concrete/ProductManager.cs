using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.concrete.InMemory;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
           _productDal.Delete(product);
        }

        public List<Product> GelAll()
        {
             return _productDal.GetAll();
        }

       

        

        public void update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
