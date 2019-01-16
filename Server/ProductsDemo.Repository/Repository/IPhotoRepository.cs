using System;
using System.Collections.Generic;
using System.Text;
using ProductsDemo.Models.Models;

namespace ProductsDemo.Repository.Repository
{
    public interface IPhotoRepository<T> where T : BaseEntity
    {
        List<Photo> GetAll();
        Photo GetById(int id);

        void Add(T product);
        Photo DeleteById(int id);
        void Update(int id, T photo);
    }
}
