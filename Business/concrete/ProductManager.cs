using Business.Abstract;
using Business.Constants;
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

        public IResults Add(Product product)
        {
            if (product.ProductName.Length <= 2)
            {
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResults Delete(Product product)
        {
           _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResults<List<Product>> GelAll()
        {
            /*if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            */
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResults<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.CategoryId == id));                  // category id benim gönderdiğim kategori id ye eşitse onları filtrele 
        }

        public IDataResults<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResults<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max)); 
        }

        public IDataResults<List<ProductDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail());
        }

        public IResults update(Product product)
        {
            _productDal.Update(product);
           return new SuccessResult(Messages.ProductUpdated) ;
        }

        
    }
}
