using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotosDemo.Repository.Repository;
using ProductsDemo.Data.EntityFramework;
using ProductsDemo.Models.Models;
using ProductsDemo.Repository.Services;

namespace ProductsDemo.Repository.Repository
{
    public class ProductDbRepository : IProductRepository<Product>
    {
        private readonly ProductDemoContext _context;

        public ProductDbRepository(ProductDemoContext context )
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product DeleteById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if(product!=null)
                _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }
    }
}
