using System.Collections.Generic;
using ProductsDemo.Models.Models;

namespace ProductsDemo.Repository.Services
{
    public interface IProductRepository<T> where T : BaseEntity
    {
        List<Product> GetAll();
        Product GetById(int id);

        void Add(T product);
        Product DeleteById(int id);
    }
}
