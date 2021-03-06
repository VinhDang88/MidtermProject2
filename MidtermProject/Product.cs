//written by Kris, Vinh and Mara 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    internal class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product(string _name, string _category, string _description, double _price)
        {
            Name = _name;
            Category = _category;
            Description = _description;
            Price = _price;

        }
        public override string ToString()
        {
            return string.Format("{0,-30} {1,-10} {2,-55} {3,-5}", $"{Name}", $"{Category}", $"{Description}", $"${Price}");
        }
    }
}