using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week17.Models
{
    public class Basket
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public String ProductType { get; set; }
        public int NumberInBasket { get; set; }

    }
}
