using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;

namespace TestConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var zz = UnitOfWork.ProductCategories.GetAll();
        }
    }
}

