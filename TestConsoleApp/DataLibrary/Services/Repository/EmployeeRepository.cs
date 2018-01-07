using DataLibrary.Models.Entities;

namespace DataLibrary.Services.Repository
{
    public class EmployeeRepository: SQLServerRepository<Employee>
    {
        protected override string TableName => "Employees";
    }
}
