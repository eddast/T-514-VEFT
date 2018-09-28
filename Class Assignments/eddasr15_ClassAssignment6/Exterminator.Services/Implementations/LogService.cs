using System.Collections.Generic;
using System.Linq;
using Exterminator.Models;
using Exterminator.Models.Dtos;
using Exterminator.Repositories.Interfaces;
using Exterminator.Services.Interfaces;

namespace Exterminator.Services.Implementations
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        /// <summary>
        /// Logs exception to database context
        /// </summary>
        /// <param name="exception">exception to log</param>
        public void LogToDatabase(ExceptionModel exception)
        {
            _logRepository.LogToDatabase(exception);
        }
        /// <summary>
        /// Retrieves all logs (LogDto) ordered by timestamp (descending)
        /// </summary>
        /// <returns>List of log dtos</returns>
        public IEnumerable<LogDto> GetAllLogs() =>
            _logRepository.GetAllLogs().OrderByDescending(l => l.Timestamp);
    }
}