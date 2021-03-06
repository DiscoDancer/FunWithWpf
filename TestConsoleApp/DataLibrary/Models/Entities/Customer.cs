﻿using DataLibrary.Attributes;

namespace DataLibrary.Models.Entities
{
    public class Customer
    {
        [PrimaryKey]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
