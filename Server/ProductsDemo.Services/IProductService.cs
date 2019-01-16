using System;
using System.Collections.Generic;
using ProductsDemo.Models.Models;

namespace ProductsDemo.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);

        void Add(Product product);
        Product DeleteById(int id);
    }
}
