using System;

namespace DataLibrary.Models
{
    public class DataLibraryException : Exception
    {
        public string Query { get; set; }
    }
}
