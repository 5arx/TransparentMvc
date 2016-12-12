using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransparentMvcLib.Classes
{
    public class Product : BaseObj
    {
        public Product() {
        }

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

    }
}