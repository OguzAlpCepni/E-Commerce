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
            return new List<Product>
            {
                new Product{ProductId = 1,ProductName="elma"},
                new Product{ProductId = 2,ProductName="armut"},
            };
        }
    }
}
