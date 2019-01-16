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
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService PhotoService)
        {
            _photoService = PhotoService;
        }

        // GET: api/Photos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_photoService.GetAll());
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _photoService.GetById(id);

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
        public IActionResult Post([FromBody] Photo photo)
        {
            _photoService.Add(photo);
            return Ok();
        }

        // PUT: api/Photos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Photo photo)
        {
            _photoService.Update(id,photo);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Photo> Delete(int id)
        {
            var result = _photoService.DeleteById(id);

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
