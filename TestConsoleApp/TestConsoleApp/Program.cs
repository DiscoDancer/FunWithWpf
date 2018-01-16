using System;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;

namespace TestConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UnitOfWork.Logs.Add(new Log
            {
                LogText = "Hello",
                LogDate = DateTime.Now
            });
        }
    }
}

