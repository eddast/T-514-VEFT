using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Exterminator.Models;
using Exterminator.Models.Dtos;
using Exterminator.Models.Entities;
using Exterminator.Repositories.Data;
using Exterminator.Repositories.Interfaces;

namespace Exterminator.Repositories.Implementations
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDbContext _dbContext = new LogDbContext();

        public void LogToDatabase(ExceptionModel exception)
        {
            _dbContext.Logs.Add(new Log
            {
                ExceptionMessage = exception.ExceptionMessage,
                StackTrace = exception.StackTrace,
                Timestamp = DateTime.Now
            });
            _dbContext.SaveChanges();
        }

        // TODO: Should contain a method which retrieves all logs (LogDto) ordered by timestamp (descending)
        /// <summary>
        /// Retrieves all logs (LogDto) ordered by timestamp (descending)
        /// </summary>
        /// <returns>List of log dtos</returns>
        public IEnumerable<LogDto> GetAllLogs() =>
            Mapper.Map<IEnumerable<LogDto>>(_dbContext.Logs.ToList());
    }
}