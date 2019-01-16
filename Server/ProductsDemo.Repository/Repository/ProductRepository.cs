using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;
using ProductsDemo.Models.Models;

namespace ProductsDemo.Repository.Services
{
    public class ProductRepository : IProductRepository<Product>
    {
        List<Product> _allItems { get; set; }

        public ProductRepository()
        {
            _allItems = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(@"C:\Temp\ProductsDemo\ProductsDemo.Repository\Repository\allItems.json"));
        }

        public List<Product> GetAll()
        {
            return _allItems;
        }

        public Product GetById(int id)
        {
            return _allItems.FirstOrDefault(x => x.Id == id);
        }

        public Product DeleteById(int id)
        {
            var item =  _allItems.FirstOrDefault(x => x.Id == id);
            if(item != null)
            _allItems.Remove(item);
            return item;

        }

        public void Add(Product product)
        {
            product.Id = _allItems.Count + 1;
             _allItems.Add(product);
        }
    }
}
