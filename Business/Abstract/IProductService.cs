using Core.Utilities.Results;
using Entities.concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResults<List<Product>> GelAll();
        IResults Add(Product product);
        IResults Delete(Product product);
        IResults update(Product product);
        IDataResults<List<Product>> GetAllByCategoryId(int id);                   // kategori id sine göre ürünleri getiren fonksiyon 
        IDataResults<List<Product>> GetByUnitPrice(decimal min, decimal max);       // şu ürün aralığında olan ürünleri getir 
        IDataResults<List<ProductDetailDto>> GetProductDetail();
        IDataResults<Product> GetById(int productId);
    }
}
