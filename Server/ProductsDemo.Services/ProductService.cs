using System;
using System.Collections.Generic;
using System.Text;
using ProductsDemo.Models.Models;
using ProductsDemo.Repository.Services;

namespace ProductsDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository<Product> _productRepository;

        public ProductService(IProductRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public Product DeleteById(int id)
        {
            return _productRepository.DeleteById(id);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}
