using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            var output = "";

            output += $"ProductID:{ProductID}\n";
            output += $"Name:{Name}\n";
            output += $"Color:{Color}\n";
            output += $"Description:{Description}\n";

            return output;
        }
    }
}
