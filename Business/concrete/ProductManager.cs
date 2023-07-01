using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.concrete.InMemory;
using Entities.concrete;
using Entities.DTOs;
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

        public IResults add(Product product)
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

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);                  // category id benim gönderdiğim kategori id ye eşitse onları filtrele 
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p=>p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max); 
        }

        public List<ProductDetailDto> GetProductDetail()
        {
           return  _productDal.GetProductDetail();
        }

        public void update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
