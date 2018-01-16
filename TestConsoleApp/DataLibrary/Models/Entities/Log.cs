using System;
using DataLibrary.Attributes;

namespace DataLibrary.Models.Entities
{
    public class Log
    {
        [PrimaryKey]
        public int LogID { get; set; }
        public string LogText { get; set; }
        public DateTime LogDate { get; set; }
    }
}
