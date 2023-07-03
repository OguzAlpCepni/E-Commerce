using Business.Abstract;
using Business.concrete;
using DataAccess.concrete.EntitiyFramework;
using Entities.concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public List<Product> get()
        {
            IProductService prodcutSerivice = new ProductManager(new EfProductDal());
            var result = prodcutSerivice.GelAll();
            return result.Data;
        }
    }
}
