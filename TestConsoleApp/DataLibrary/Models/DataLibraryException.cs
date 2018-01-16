using System;

namespace DataLibrary.Models
{
    public class DataLibraryException : Exception
    {
        public string Method { get; set; }
        public string Query { get; set; }
        public Exception HandledException { get; set; }
    }
}
