using System;
using System.Collections.Generic;
using ProductsDemo.Models.Models;

namespace PhotosDemo.Services
{
    public interface IPhotoService
    {
        List<Photo> GetAll();
        Photo GetById(int id);

        void Add(Photo Photo);
        Photo DeleteById(int id);
    }
}
