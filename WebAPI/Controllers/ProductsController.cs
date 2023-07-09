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
        [HttpGet("getall")]
        public IActionResult Get()
        {   // dependency chain
            var result = _productService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _productService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
