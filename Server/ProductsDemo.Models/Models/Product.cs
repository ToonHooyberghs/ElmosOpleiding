using System.ComponentModel.DataAnnotations;

namespace ProductsDemo.Models.Models
{
    public class Product : BaseEntity
    {

        public Product()
        {
            
        }

        public Product(int? id, string make, string model, int year, decimal price)
        {
            
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }

        [Required]
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}
