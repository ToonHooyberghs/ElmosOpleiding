using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProductsDemo.Models.Models;

namespace ProductsDemo.Data.EntityFramework
{
    public class ProductDemoContext : DbContext
    {

        public ProductDemoContext(DbContextOptions<ProductDemoContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Photo> Photos { get; set; }

    }
}
