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
    {   // loosly coupled 
        // naming conventation 
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService; 
        }
        [HttpGet]
        public IActionResult get()
        {   // dependency chain
            var result = _productService.GelAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
