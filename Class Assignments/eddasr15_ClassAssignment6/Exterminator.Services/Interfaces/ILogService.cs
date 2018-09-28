using System.Collections.Generic;
using Exterminator.Models;
using Exterminator.Models.Dtos;

namespace Exterminator.Services.Interfaces
{
    public interface ILogService
    {
        /// <summary>
        /// Logs exception to database context
        /// </summary>
        /// <param name="exception">the exception to log</param>
         void LogToDatabase(ExceptionModel exception);

        /// <summary>
        /// Retrieves all logs (LogDto) ordered by timestamp (descending)
        /// </summary>
        /// <returns>List of log dtos</returns>
        IEnumerable<LogDto> GetAllLogs();
    }
}