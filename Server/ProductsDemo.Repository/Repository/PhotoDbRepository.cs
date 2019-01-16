using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotosDemo.Repository.Repository;
using ProductsDemo.Data.EntityFramework;
using ProductsDemo.Models.Models;
using ProductsDemo.Repository.Services;

namespace ProductsDemo.Repository.Repository
{
    public class PhotoDbRepository : IPhotoRepository<Photo>
    {
        private readonly ProductDemoContext _context;

        public PhotoDbRepository(ProductDemoContext context)
        {
            _context = context;
        }

        public void Add(Photo photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }

        public Photo DeleteById(int id)
        {
            var photo = _context.Photos.FirstOrDefault(x => x.Id == id);
            if (photo != null)
                _context.Photos.Remove(photo);
            _context.SaveChanges();
            return photo;
        }

        public List<Photo> GetAll()
        {
            return _context.Photos.ToList();
        }

        public Photo GetById(int id)
        {
            return _context.Photos.FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, Photo photo)
        {
            throw new NotImplementedException();
        }
    }
}
