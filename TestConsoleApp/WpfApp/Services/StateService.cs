﻿using DataLibrary.Models;
using DataLibrary.Models.Entities;

namespace WpfApp.Services
{
    public static class StateService
    {
        public static Customer CurrentCustomer { get; set; }
        public static Employee CurrentEmployee { get; set; }
        public static Product CurrentProduct { get; set; }
        public static ExtendedOrder CurrentOrder { get; set; }
        public static ProductCategory CurrentCategory { get; set; }
    }
}
