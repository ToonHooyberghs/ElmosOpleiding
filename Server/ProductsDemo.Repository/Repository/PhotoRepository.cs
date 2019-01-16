using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ProductsDemo.Models.Models;
using ProductsDemo.Repository.Repository;

namespace PhotosDemo.Repository.Repository
{
    public class PhotoRepository : IPhotoRepository<Photo>
    {
        List<Photo> _allItems { get; set; }

        public PhotoRepository()
        {
            _allItems = JsonConvert.DeserializeObject<List<Photo>>(File.ReadAllText(@"C:\Temp\ProductsDemo\ProductsDemo.Repository\Repository\allphotos.json"));
        }

        public List<Photo> GetAll()
        {
            return _allItems;
        }

        public Photo GetById(int id)
        {
            return _allItems.FirstOrDefault(x => x.Id == id);
        }

        public Photo DeleteById(int id)
        {
            var item = _allItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
                _allItems.Remove(item);
            return item;

        }

        public void Add(Photo Photo)
        {
            Photo.Id = _allItems.Count + 1;
            _allItems.Add(Photo);
        }
    }
}
