using DataLibrary.Models.Entities;

namespace DataLibrary.Services.Repository
{
    public class LogRepository: SQLServerRepository<Log>
    {
        protected override string TableName { get; } = "Logs";
    }
}
