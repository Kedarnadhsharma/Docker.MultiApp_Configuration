using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docker.MultiApp.API.Models
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public decimal Price { get; set; }
      
        public string Category { get; set; }
    }
}
