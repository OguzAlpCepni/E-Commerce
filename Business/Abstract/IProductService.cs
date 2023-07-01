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
        List<Product> GelAll();
        IResults add(Product product);
        void Delete(Product product);
        void update(Product product);
        List<Product> GetAllByCategoryId(int id);                   // kategori id sine göre ürünleri getiren fonksiyon 
        List<Product> GetByUnitPrice(decimal min, decimal max);       // şu ürün aralığında olan ürünleri getir 
        List<ProductDetailDto> GetProductDetail();
        Product GetById(int productId);
    }
}
