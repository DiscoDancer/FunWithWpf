using DataLibrary;
using System.Collections.Generic;

namespace WpfApp.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public List<ValueID> CustomersList { get; set; }
    }
}
