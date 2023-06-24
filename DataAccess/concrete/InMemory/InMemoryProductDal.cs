using DataAccess.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.InMemory
{
    //I haven't got Db for this project at the moment .I will add DB and EF  
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductName = "Bardak",
                    UnitPrice = 15,
                    UnitsInStock=15
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 3,
                    ProductName = "Fincan",
                    UnitPrice = 14,
                    UnitsInStock=18
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 3,
                    ProductName = "Tabak",
                    UnitPrice = 18,
                    UnitsInStock=10,
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 5,
                    ProductName = "Catal",
                    UnitPrice = 13,
                    UnitsInStock=19
                },
                new Product { 
                    ProductId = 5,
                    CategoryId = 6,
                    ProductName = "Kase",
                    UnitPrice = 13,
                    UnitsInStock=10, 
                }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product ProductToDelete = new Product(); bellegi fazla yordun gerek yok 

            Product ProductToDelete = null;
            //linq -language  Integrated  query 
            //foreach (var p in _products) // this code == SingleOrDefault(p=>);
            
            ProductToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(ProductToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            // where içindeki şarta uyan butun  elemanları yeni bir liste haline getirip döndürür
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        

        public void Update(Product product)
        {// gonderdiim urun id sine sahip olan listedeki ürünü  bul 
            Product productToUpdate = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
           productToUpdate.ProductName= product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
