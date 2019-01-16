using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProductsDemo.Models.Models;
using ProductsDemo.Services;

namespace ProductsDemo.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOptions<BeOneSettings> _beOneSettings;

        public ProductsController(IProductService productService , IOptions<BeOneSettings> beOneSettings)
        {
            _productService = productService;
            _beOneSettings = beOneSettings;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            return Ok(_productService.GetAll());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _productService.Add(product);
            return Ok();
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var result = _productService.DeleteById(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
