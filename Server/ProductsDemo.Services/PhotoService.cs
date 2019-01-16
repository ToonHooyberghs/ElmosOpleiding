using System.Collections.Generic;
using ProductsDemo.Models.Models;
using ProductsDemo.Repository.Repository;

namespace PhotosDemo.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository<Photo> _PhotoRepository;

        public PhotoService(IPhotoRepository<Photo> PhotoRepository)
        {
            _PhotoRepository = PhotoRepository;
        }

        public void Add(Photo photo)
        {
            _PhotoRepository.Add(photo);
        }

        public void Update(int id, Photo photo)
        {
            _PhotoRepository.Update(id,photo);
        }

        public Photo DeleteById(int id)
        {
            return _PhotoRepository.DeleteById(id);
        }

        public List<Photo> GetAll()
        {
            return _PhotoRepository.GetAll();
        }

        public Photo GetById(int id)
        {
            return _PhotoRepository.GetById(id);
        }
    }
}
