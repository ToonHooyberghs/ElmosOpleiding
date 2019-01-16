using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotosDemo.Services;
using ProductsDemo.Models.Models;

namespace ProductsDemo.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    [Authorize]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _PhotoService;

        public PhotosController(IPhotoService PhotoService)
        {
            _PhotoService = PhotoService;
        }

        // GET: api/Photos
        [HttpGet]
        public IActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            return Ok(_PhotoService.GetAll());
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _PhotoService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // POST: api/Photos
        [HttpPost]
        public IActionResult Post([FromBody] Photo Photo)
        {
            _PhotoService.Add(Photo);
            return Ok();
        }

        // PUT: api/Photos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Photo> Delete(int id)
        {
            var result = _PhotoService.DeleteById(id);

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
