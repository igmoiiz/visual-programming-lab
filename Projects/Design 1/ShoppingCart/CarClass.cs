using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    internal class CarClass
    {
        //  public variables
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        //  default constructor
        public CarClass() 
        {
            Make = "Nothing Yet";
            Model = "Nothing Yet";
            Price = 0.00M;
        }

        //  parameterised Constructor
        public CarClass(string make, string model, decimal price)
        {
            Make = make;
            Model = model;
            Price = price;
        }
    }
}
